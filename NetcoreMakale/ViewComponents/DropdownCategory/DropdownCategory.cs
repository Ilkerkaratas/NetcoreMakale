using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.DropdownCategory
{
    public class DropdownCategory:ViewComponent
    {
        Categorymanager Categorymanager = new Categorymanager(new CategoryRepository());
        public IViewComponentResult Invoke()
        {
            var value = Categorymanager.GetList();
            value.Reverse();
            return View(value);
        }
    }
}
