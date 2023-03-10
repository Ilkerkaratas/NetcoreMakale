using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YorumController : Controller
    {
        YorumManager manager = new YorumManager(new YorumRepository());
        public IActionResult Index()
        {
            var value = manager.GetList();
            return View(value);
        }
        public IActionResult YorumDelete(int id)
        {
            manager.Delete(x=>x.YorumID==id);
            return RedirectToAction("");
        }
    }
}
