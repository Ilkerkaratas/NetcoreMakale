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
    [Authorize(Roles = "Admin,User")]
    public class MakaleController : Controller
    {
        UserManager UserManager = new UserManager(new UserRepository());
        MakaleManager manager = new MakaleManager(new MakaleRepository());
        public IActionResult Index()
        {
            var user = UserManager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name);
            if (user.role=="Admin")
            {
                var value = manager.GetList();
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
        public IActionResult MakaleEdit(Makale makale)
        {
            manager.Update(makale);

            return RedirectToAction("");
        }
        public IActionResult MakaleDelete(int id)
        {
            var makale = manager.GetByFilter(x=>x.MakaleID==id);
            var user = UserManager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
            if (user.UserID==makale.UserID || user.role=="Admin")
            {
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
        public IActionResult MakaleAdd(Makale makale)
        {
            var user = UserManager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
            makale.MakaleStatus = true;
            makale._Like = 0;
            makale.UserID = user.UserID;
            manager.Add(makale);
            return View();
        }
    }
}
