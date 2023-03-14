﻿using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.GetUserimg
{

    public class GetUserimg:ViewComponent
    {
        UserManager user = new UserManager(new UserRepository());
        public IViewComponentResult Invoke()
        {


            var values = user.GetByFilter(x => x.KullaniciAdi==User.Identity.Name);
            ViewBag.img = values.KullaniciResim;

            return View();
        }
    }
}
