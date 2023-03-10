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
        //Category Id ye Göre Category İsmi Getir
        public IViewComponentResult Invoke()
        {
            var value = manager.GetList();
            


            return View(value);
        }
    }
}
