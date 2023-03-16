using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Controllers
{
    [Authorize(Roles = "Admin")]
    //sadece rolü admin olan kullanıcılar kategori ekleyebilir.
    public class CategoryController : Controller
    {
        Categorymanager manager = new Categorymanager(new CategoryRepository());
        MakaleManager makale_manager = new MakaleManager(new MakaleRepository());
        public IActionResult Index()
        {
            var model = manager.GetList();
            model.Reverse();
            return View(model);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            category.CategoryStatus = true;
            manager.Add(category);
            return RedirectToAction("");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var values = manager.GetByFilter(x=>x.CategoryID==id);
            return View(values);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category,String status)
        {
            if (status == "1")
            {
                category.CategoryStatus = true;
            }
            else
            {
                category.CategoryStatus = false;
            }
            manager.Update(category);
            return RedirectToAction("");
        }
        public IActionResult CategoryDelete(int id) 
        {
            var makale = makale_manager.GetByFilter(x => x.CategoryID == id);
            if (makale is not null)
            {
                makale.CategoryID = 0;
                makale_manager.Update(makale);
            }
            manager.Delete(x=>x.CategoryID==id);
            return RedirectToAction("");
        }
    }
}
