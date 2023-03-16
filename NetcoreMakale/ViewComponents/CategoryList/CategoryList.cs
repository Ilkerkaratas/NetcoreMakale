using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.CategoryList
{
    public class CategoryList:ViewComponent
    {
        Categorymanager manager = new Categorymanager(new CategoryRepository());
        //Veri tabanında kayıtlı olan bütün kategori bilgilerini görünüme gönderir.
        public IViewComponentResult Invoke()
        {
            var value = manager.GetList();
            


            return View(value);
        }
    }
}
