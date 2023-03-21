using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.ViewComponents.GetContact
{
    public class GetContact : ViewComponent
    {
        ContactManager ContactManager = new ContactManager(new ContactRepository());
        public IViewComponentResult Invoke()
        {
            var value = ContactManager.GetList();
            value.Reverse();
            return View(value);
        }
    }
}
