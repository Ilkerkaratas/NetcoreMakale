using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetcoreMakale.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Controllers
{
    
    public class UserController : Controller
    {

        //admin tüm kullanıcıları görebeilir silebilir ve rollerini değiştirebilir
        //kullanıcılar sadece kendi bilgilerini güncelleyebilie ancak rollerini değiştiremezler.
        UserManager user_manager = new UserManager(new UserRepository());
        LikeManager like_manager = new LikeManager(new LikeRepository());
        YorumManager yorum_manager = new YorumManager(new YorumRepository());
        MakaleManager makale_manager = new MakaleManager(new MakaleRepository());
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var value = user_manager.GetList();
            value.Reverse();
            return View(value);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            var value = user_manager.GetByFilter(x => x.UserID == id);
            return View(value);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> UserEdit(User user, IFormFile file)
        {
            string eimage = user.KullaniciResim;
            if (file != null)
            {
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
                            user.KullaniciResim = ImageName;

                        }
                    }

                }
                if (ImageName != null)
                {
                    eimage = ImageName;
                }
            }
            user.KullaniciResim = eimage;

            user_manager.Update(user);
            var value = user_manager.GetByFilter(x => x.UserID == user.UserID);
            return View(value);
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult UserDelete(int id)
        {
            var like = like_manager.GetList(x => x.UserID == id);
            var makale = makale_manager.GetList(x => x.UserID == id);
            var yorum = yorum_manager.GetList(x => x.UserID == id);
            var user = user_manager.GetByFilter(x => x.UserID == id);
            if (like is not null)
            {
                foreach (var item in like)
                {
                    like_manager.Delete(x => x.UserID == item.UserID);
                }

            }
            if (makale is not null)
            {
                foreach (var item in makale)
                {
                    makale_manager.Delete(x => x.UserID == item.MakaleID);
                }
            }
            if (yorum is not null)
            {
                foreach (var item in yorum)
                {
                    yorum_manager.Delete(x => x.UserID == item.YorumID);
                }
            }
            if (user.KullaniciResim is not null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\MakaleImg", user.KullaniciResim);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            user_manager.Delete(x => x.UserID == id);
            if (User.IsInRole("Admin"))
            {
               
                return RedirectToAction("");
            }
            else
            {
               return RedirectToAction("Home","Index");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddUser(User user, IFormFile file)
        {
            if (file != null)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png")
                { 
                    string ImageName = $@"{Guid.NewGuid()}.jpeg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UserImg", ImageName);

                    // using Kullanmak demek.
                    //var stream =new FileStream oluşuturup path ve filemode.create diyoruz.
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    user.KullaniciResim = ImageName;
                }
            }



            user_manager.Add(user);

            return RedirectToAction("");
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        //Kullanıcı ayarları sayfası
        public IActionResult UserOp()
        {
            var value = user_manager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
            return View(value);
        }
      
    }
}
