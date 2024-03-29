﻿using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.GetYorum_User
{
    public class GetYorum_User:ViewComponent
    {
       
        UserManager user = new UserManager(new UserRepository());
        public IViewComponentResult Invoke(Yorum yorum)
        {
            //yorumu yapan kişinin kullanıcı bilgilerini görünüm katmanına taşır.

            var values = user.GetByFilter(x => x.UserID == yorum.UserID);


            return View(values);
        }
    }
}
