using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetcoreMakale.Models;
using System.Diagnostics;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;

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
        ContactManager ContactManager = new ContactManager(new ContactRepository());
        Categorymanager categorymanager = new Categorymanager(new CategoryRepository());
        FollowManager followManager = new FollowManager(new FollowRepository());

        [HttpGet]
        public IActionResult Contact()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ////mail gönderme pcden mail gönderme iznim olmadığı için kapattım.
                //MimeMessage mimeMessage = new MimeMessage();
                //MailboxAddress mailboxAddressFrom = new MailboxAddress("İlker Karataş", "ilkerkaratas94@gmail.com");

                //mimeMessage.From.Add(mailboxAddressFrom);
                //MailboxAddress mailBoxAddressTo = new MailboxAddress(contact.Name, contact.ContactMail);
                //mimeMessage.To.Add(mailBoxAddressTo);
                //mimeMessage.Subject = contact.subject;
                //var bodybuilder = new BodyBuilder();
                //bodybuilder.TextBody = contact.Contacttext;
                //mimeMessage.Body = bodybuilder.ToMessageBody();
                //SmtpClient smtp = new SmtpClient();
                //smtp.Connect("smtp.gmail.com", 587, false);
                //smtp.Authenticate("ilkerkaratas94@gmail.com", "fgalkazvztijlmor");
                //smtp.Send(mimeMessage);
                //smtp.Disconnect(true);


                ////Başka bir yöntem
                //MailMessage Eposta = new MailMessage();
                ////Kİmden
                //Eposta.From = new MailAddress("karatasilker25@gmail.com", "İlker Karataş");
                ////Kime Gönderilecek
                //Eposta.To.Add(new MailAddress(contact.ContactMail, contact.Name));
                //Eposta.Subject = contact.subject;
                //Eposta.Body = contact.Contacttext;
                //Eposta.Priority = MailPriority.High;
                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //NetworkCredential AccountInfo = new NetworkCredential("ilkerkaratas94@gmail.com", "apbelqwqsriocfix");
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = AccountInfo;
                //smtp.EnableSsl = true;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Send(Eposta);



                ContactManager.Add(contact);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
          
        }
        public IActionResult Index()
            
        {
            var model = M_Manager.GetList();
            model.Reverse();
            return View(model);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        //makale ıdye göre sadece 1 makalenin bilgilerinin gösterildiği sayfa
        public IActionResult MakaleDetail(int id)
        {
            var Kullanıcı = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name);
            var like = LikeManager.GetByFilter(x => x.UserID == Kullanıcı.UserID && x.MakaleID==id);
            var model = M_Manager.GetByFilter(x=>x.MakaleID==id);
            var follow = followManager.GetByFilter(x=>x.TakiEdenID==Kullanıcı.UserID && x.TakipEdilenID== model.UserID);
            var user = User_Manager.GetByFilter(x => x.UserID == model.UserID);
            if (like is not null)
            {
                ViewBag.like = like.Lİke_;
            }
            else
            {
                ViewBag.like = false;
            }
            if (follow is not null)
            {
                ViewBag.follow = follow.statu;
            }
            else
            {
                ViewBag.follow = false;
            }


            ViewBag.takip = user.takipcisayisi.ToString() ;
            ViewBag.UserName = user.KullaniciAdi;
            return View(model);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public IActionResult MakaleDetail(int MakaleId, string yorum)
        {
          


            //giriş yapan kullanıcı
            var Kullanıcı = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name);
            //Giriş yapan kullanıcının ilgili makelyle ilgili like bilgileri.
            var like = LikeManager.GetByFilter(x => x.UserID == Kullanıcı.UserID && x.MakaleID == MakaleId);
            var model = M_Manager.GetByFilter(x => x.MakaleID == MakaleId);
            var user = User_Manager.GetByFilter(x => x.UserID == model.UserID);
            var takip = followManager.GetByFilter(x=>x.TakipEdilenID==model.UserID && x.TakiEdenID==Kullanıcı.UserID);
            //kullanıcının like atıp atmadığı bilgisi
            if (like is not null) 
            {
                ViewBag.like = like.Lİke_;
            }
            else
            {
                ViewBag.like = false;
            }
            
            if(takip is not null)
            {
                ViewBag.follow = takip.statu;
            }
            else
            {
                ViewBag.follow = false;
            }
            //Kullanıcının User idsi
            int userID = User_Manager.GetByFilter(x => x.KullaniciAdi == User.Identity.Name).UserID;
            Yorum y = new Yorum();
            y.MakaleID = MakaleId;
            y.UserID = userID;
            y.yorum_text = yorum;

            yorum_M.Add(y);
            
           
            ViewBag.takip = user.takipcisayisi.ToString() ;
            ViewBag.UserName = user.KullaniciAdi;
            return View(model);
        }
        [Authorize(Roles = "User,Admin")]
        //makaledetail sayfasından makale idye göre kullanıcının like işlemlerini yapması için like sayfası
        //bir view döndermiyor.
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
        public IActionResult Takip(int userid, int MakaleID)
        {
            //makale detail kısmında actionlinkle geliyo buraya
            var takipeden = User_Manager.GetByFilter(x=>x.KullaniciAdi==User.Identity.Name);
            var takipedilen = User_Manager.GetByFilter(x=>x.UserID== userid);
            var takip = followManager.GetByFilter(x=>x.TakiEdenID==takipeden.UserID && x.TakipEdilenID==takipedilen.UserID);
            if(takip is null)
            {
                Follow follow = new Follow();
                follow.TakiEdenID = takipeden.UserID;
                follow.TakipEdilenID = takipedilen.UserID;
                follow.statu = true;
                followManager.Add(follow);
                takipedilen.takipcisayisi++;
            }
            else
            {
                if (takip.statu != true)
                {
                    takipedilen.takipcisayisi++;
                    takip.statu = true;

                }
                else if (takipedilen.takipcisayisi != 0)
                {
                    takip.statu = false;
                    takipedilen.takipcisayisi--;
                }
                else
                {
                    takipedilen.takipcisayisi++;
                    takip.statu= true;
                }
                followManager.Update(takip);
            }
            User_Manager.Update(takipedilen);
            return RedirectToAction("MakaleDetail", new { id = MakaleID });
        }
        public IActionResult Category_Makale(int id)
        {
            var Category = categorymanager.GetByFilter(x=>x.CategoryID==id);
            //kategori ismi genelse tümünü listele..
            if (Category.CategoryName=="Genel")
            {
                var value = M_Manager.GetList();
                return View(value);
            }
            else
            {
                var value = M_Manager.GetList(x => x.CategoryID == id);

                return View(value);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
