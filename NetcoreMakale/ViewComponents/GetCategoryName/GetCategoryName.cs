using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.GetCategoryName
{
    public class GetCategoryName:ViewComponent
    {
        Categorymanager manager = new Categorymanager(new CategoryRepository());
        //Category Id ye Göre Category İsmi Getir
        public IViewComponentResult Invoke(int id)
        {
            var value = manager.GetByFilter(x => x.CategoryID == id);
            ViewBag.CategoryName = value.CategoryName;


            return View();
        }
    }
}
