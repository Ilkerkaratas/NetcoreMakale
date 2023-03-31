using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Controllers
{
    public class FollowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
