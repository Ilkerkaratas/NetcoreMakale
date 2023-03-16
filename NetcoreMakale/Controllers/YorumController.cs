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
        //Admin yorumları admin panalden görebilir ve silebilir.
        //kullanıcıların kendi yorumlarını silmesi iiçin düzenleme yapılacak.
        YorumManager manager = new YorumManager(new YorumRepository());
        public IActionResult Index()
        {
            var value = manager.GetList();
            value.Reverse();
            return View(value);
        }
        public IActionResult YorumDelete(int id)
        {
            manager.Delete(x=>x.YorumID==id);
            return RedirectToAction("");
        }
    }
}
