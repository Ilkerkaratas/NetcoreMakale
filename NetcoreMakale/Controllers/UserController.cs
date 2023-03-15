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
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        UserManager user_manager = new UserManager(new UserRepository());
        LikeManager like_manager = new LikeManager(new LikeRepository());
        YorumManager yorum_manager = new YorumManager(new YorumRepository());
        MakaleManager makale_manager = new MakaleManager(new MakaleRepository());
        public IActionResult Index()
        {
            var value = user_manager.GetList();
            value.Reverse();
            return View(value);
        }

        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            var value = user_manager.GetByFilter(x => x.UserID == id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(User user, IFormFile file)
        {
            string eimage = user.KullaniciResim;
            string ImageName =file.FileName;
         
            if (eimage != ImageName)
            {
                if (file != null)
                {
                    if (eimage != null)
                    {
                        System.IO.File.Delete(@"wwwroot\UserImg\" + eimage);
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

            user.KullaniciResim = eimage;

            user_manager.Update(user);
            var value = user_manager.GetByFilter(x => x.UserID == user.UserID);
            return View(value);
        }
        public IActionResult UserDelete(int id)
        {
            var like = like_manager.GetList(x => x.UserID == id);
            var makale = makale_manager.GetList(x => x.UserID == id);
            var yorum = yorum_manager.GetList(x => x.UserID == id);
            var user = user_manager.GetByFilter(x=>x.UserID == id);
            if (like is not null)
            {
                foreach (var item in like)
                {
                    like_manager.Delete(x => x.UserID ==item.UserID);
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
            System.IO.File.Delete(@"wwwroot\UserImg\" + user.KullaniciResim);

            user_manager.Delete(x => x.UserID == id);
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }
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


    }
}
