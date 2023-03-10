using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var value = user_manager.GetByFilter(x=>x.UserID==id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            user_manager.Update(user);
            var value = user_manager.GetByFilter(x => x.UserID == user.UserID);
            return View(value);
        }
        public IActionResult UserDelete(int id)
        {
            var like = like_manager.GetByFilter(x=>x.UserID==id);
            var makale=makale_manager.GetByFilter(x => x.UserID == id);
            var yorum=yorum_manager.GetByFilter(x => x.UserID == id);
            if (like is not null)
            {
                like_manager.Delete(x=>x.UserID==id);
            }
            if (makale is not null)
            {
                makale_manager.Delete(x => x.UserID == id);
            }
            if (yorum is not null)
            {
                yorum_manager.Delete(x => x.UserID == id);
            }
            user_manager.Delete(x=>x.UserID==id);
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            user_manager.Add(user);

            return RedirectToAction("");
        }


    }
}
