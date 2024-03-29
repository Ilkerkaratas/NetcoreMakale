﻿using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.GetIDUserName
{
    public class GetIDUserName:ViewComponent
    {
        UserManager manager = new UserManager(new UserRepository());
        //user idye göre kullanıcı isimlerini taşır.
        //yorum yapan ve makale yazan kişinin adını çekebilmek için yaptım.
        public IViewComponentResult Invoke(int id)
        {
            var value = manager.GetByFilter(x => x.UserID == id);
            ViewBag.UserName = value.KullaniciAdi;


            return View();
        }
    }
}
