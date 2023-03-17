using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NetcoreMakale.Controllers
{
    [Authorize(Roles = "Admin,User")]
    //admin ve user ların kullanabileceği bir makale işlemleri sayfası layoutları admin veya user olmasına göre değişiyor.
    //Rolü user olanlar sadece kendi makaleleriyle işlemler yapabiliyor.
    //Admin rolü olan kullanıcı bütün makalelere erişebilir ve onlarla ilgili tüm işlemleri yapabilir.
    public class MakaleController : Controller
    {
        UserManager UserManager = new UserManager(new UserRepository());
        MakaleManager manager = new MakaleManager(new MakaleRepository());
        LikeManager like_manager = new LikeManager(new LikeRepository());
        YorumManager yorum_manager = new YorumManager(new YorumRepository());
        public IActionResult Index()
        {
            var user = UserManager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name);
            if (user.role=="Admin")
            {
                var value = manager.GetList();
                value.Reverse();
                return View(value);
            }
            else
            {
                
                var value = manager.GetList(x=>x.UserID==user.UserID);
                return View(value);
            }
            
        }
        [HttpGet]
        public IActionResult MakaleEdit(int id)
        {
            var value = manager.GetByFilter(x => x.MakaleID == id);
            var user = UserManager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
            if (user.UserID==value.UserID || user.role=="Admin"){
                
                return View(value);
            }
            else
            {
                return RedirectToAction("");
            }
            
           
        }
        [HttpPost]
        public async Task<IActionResult> MakaleEdit(Makale makale,IFormFile file)
        {
            string eimage = makale.MakaleResim;
            string ImageName = file.FileName;

            if (eimage != ImageName)
            {
                if (file != null)
                {
                    if (eimage != null)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\MakaleImg", eimage);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }
                    if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png")
                    {
                        ImageName = $@"{Guid.NewGuid()}.jpeg";
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UserImg", ImageName);

                        // using Kullanmak demek.
                        //var stream =new FileStream oluşuturup path ve filemode.create diyoruz.
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        makale.MakaleResim = ImageName;

                    }
                }

            }
            if (ImageName != null)
            {
                eimage = ImageName;
            }

            makale.MakaleResim = eimage;


            manager.Update(makale);

            return RedirectToAction("");
        }
        public IActionResult MakaleDelete(int id)
        {
            var makale = manager.GetByFilter(x=>x.MakaleID==id);
            var user = UserManager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
           
            if (user.UserID==makale.UserID || user.role=="Admin")
            {
                var like = like_manager.GetList(x => x.MakaleID == makale.MakaleID);
                var yorum = yorum_manager.GetList(x => x.MakaleID == makale.MakaleID);
                if (like.Count != 0)
                {
                    foreach (var item in like)
                    {
                        like_manager.Delete(x => x.MakaleID == item.MakaleID);
                    }
                    
                }
                if(yorum.Count != 0)
                {
                    foreach (var item in yorum)
                    {
                        yorum_manager.Delete(x => x.MakaleID == item.MakaleID);
                    }
                    
                }
                if (makale.MakaleResim is not null)
                {
                   
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\MakaleImg", makale.MakaleResim);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    
                    
                }
                manager.Delete(x => x.MakaleID == id);
            }
            
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult MakaleAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MakaleAdd(Makale makale,IFormFile file)
        {
            var user = UserManager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
            makale.MakaleStatus = true;
            makale._Like = 0;
            makale.UserID = user.UserID;
            if (file != null)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png")
                {
                    string ImageName = $@"{Guid.NewGuid()}.jpeg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\MakaleImg", ImageName);

                    // using Kullanmak demek.
                    //var stream =new FileStream oluşuturup path ve filemode.create diyoruz.
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    makale.MakaleResim = ImageName;
                }
            }
            manager.Add(makale);
            return RedirectToAction("") ;
        }
    }
}
