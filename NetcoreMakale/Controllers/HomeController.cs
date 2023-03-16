using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetcoreMakale.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;

namespace NetcoreMakale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        MakaleManager M_Manager = new MakaleManager(new MakaleRepository());
        UserManager User_Manager = new UserManager(new UserRepository());
        YorumManager yorum_M = new YorumManager(new YorumRepository());
        LikeManager LikeManager = new LikeManager(new LikeRepository());

        public IActionResult Index()
            
        {
           
            var model = M_Manager.GetList();
            model.Reverse();
            return View(model);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult MakaleDetail(int id)
        {
            var Kullanıcı = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name);
            var like = LikeManager.GetByFilter(x => x.UserID == Kullanıcı.UserID && x.MakaleID==id);
            if (like is not null)
            {
                ViewBag.like = like.Lİke_;
            }
            else
            {
                ViewBag.like = false;
            }
            var model = M_Manager.GetByFilter(x => x.MakaleID == id);
            var user = User_Manager.GetByFilter(x => x.UserID == model.UserID);
            ViewBag.UserName = user.KullaniciAdi;
            return View(model);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public IActionResult MakaleDetail(int MakaleId, string yorum)
        {
            //giriş yapan kullanıcı
            var Kullanıcı = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name);
            var like = LikeManager.GetByFilter(x => x.UserID == Kullanıcı.UserID && x.MakaleID == MakaleId);
            ViewBag.like = like.Lİke_;
            int userID = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name).UserID;
            Yorum y = new Yorum();
            y.MakaleID = MakaleId;
            y.UserID = userID;
            y.yorum_text = yorum;

            yorum_M.Add(y);
            var model = M_Manager.GetByFilter(x => x.MakaleID == MakaleId);
            var user = User_Manager.GetByFilter(x => x.UserID == model.UserID);
            ViewBag.UserName = user.KullaniciAdi;
            return View(model);
        }
        [Authorize(Roles = "User,Admin")]
        
        public IActionResult MakaleLike(int MakaleID)
        {
            
            int userid = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name).UserID;
            var makale = M_Manager.GetByFilter(x => x.MakaleID == MakaleID);

            var UserLİke = LikeManager.GetByFilter(x => x.MakaleID == MakaleID && x.UserID == userid);
            if (UserLİke is not null)
            {
                
                if (UserLİke.Lİke_ != true)
                {
                    makale._Like++;
                    UserLİke.Lİke_ = true;
                    
                }
                else if (makale._Like != 0)
                {
                    UserLİke.Lİke_ = false;
                    makale._Like--;
                }
                else
                {
                    makale._Like++;
                    UserLİke.Lİke_ = true;
                }
                LikeManager.Update(UserLİke);
            }
            else
            {
                Like like = new Like();
                like.UserID = userid;
                like.MakaleID = makale.MakaleID;
                like.Lİke_ = true;
                LikeManager.Add(like);
                makale._Like = makale._Like + 1;
            }


           

            M_Manager.Update(makale);

            return RedirectToAction("MakaleDetail", new { id = MakaleID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
