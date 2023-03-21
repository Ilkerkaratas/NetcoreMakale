using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using EntityLayer;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ContactManager contactManager = new ContactManager(new ContactRepository());
        public IActionResult ContactDetail(int id)
        {
            var value = contactManager.GetByFilter(x=>x.ContactID==id);
            return View(value);
        }
        [HttpGet]
        public IActionResult Cevap(int id)
        {
            var value = contactManager.GetByFilter(x => x.ContactID == id);
            return View(value);
        } 
        [HttpPost]
        public IActionResult Cevap(string subject,string text,int ContactID)
        {
            //var contact= contactManager.GetByFilter(x=>x.ContactID==ContactID);
            ////mail gönderme pcden mail gönderme iznim olmadığı için kapattım.
            ////Test edilip düzenlenmesi gerekiyor.
            //MimeMessage mimeMessage = new MimeMessage();
            //MailboxAddress mailboxAddressFrom = new MailboxAddress("İlker Karataş", "ilkerkaratas94@gmail.com");

            //mimeMessage.From.Add(mailboxAddressFrom);
            //MailboxAddress mailBoxAddressTo = new MailboxAddress(contact.Name, contact.ContactMail);
            //mimeMessage.To.Add(mailBoxAddressTo);
            //mimeMessage.Subject = subject;
            //var bodybuilder = new BodyBuilder();
            //bodybuilder.TextBody = text;
            //mimeMessage.Body=bodybuilder.ToMessageBody();
            //SmtpClient smtp = new SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, false);
            //smtp.Authenticate("ilkerkaratas94@gmail.com", "fgalkazvztijlmor");
            //smtp.Send(mimeMessage);
            //smtp.Disconnect(true);
            return RedirectToAction("/");
        }
        public IActionResult Index()
        {

            return View();
        }

    }
}
