using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.YUserimg
{
    public class YUserimg:ViewComponent
    {
        UserManager user = new UserManager(new UserRepository());
        public IViewComponentResult Invoke(Yorum yorum)
        {


            var values = user.GetByFilter(x => x.UserID == yorum.UserID);
            ViewBag.img = values.KullaniciResim;

            return View();
        }
    }
}
