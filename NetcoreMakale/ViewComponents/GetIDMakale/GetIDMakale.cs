﻿using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.GetIDMakale
{
    public class GetIDMakale:ViewComponent
    {
        MakaleManager manager = new MakaleManager(new MakaleRepository());
        public IViewComponentResult Invoke(int id )
        {
            //makale idye göre makale başlıklarını viewbag ile taşır
            try
            {
                var value = manager.GetByFilter(x => x.MakaleID == id);
                if(value is not null)
                {
                    ViewBag.MakaleBaşlik = manager.GetByFilter(x => x.MakaleID == id).MakaleBaşlik;
                }
                
            }
            catch { }
                


            return View();
        }
    }
}
