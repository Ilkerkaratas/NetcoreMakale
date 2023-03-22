﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BusinessLayer.Concrete;
using DataAccesLayer.Repostories;
using Microsoft.AspNetCore.Identity;
using EntityLayer;

namespace NetcoreMakale.Controllers
{
    //kayıt giriş ve çıkış işlmeleri
    public class AccountController : Controller
    {
        
       
        UserManager manager = new UserManager(new UserRepository());
       
        [HttpGet]
        public IActionResult Login()
        {
            
            @ViewBag.f = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Ad, string Sifre)
        {
            @ViewBag.f = 1;
            try
            {
                if (string.IsNullOrEmpty(Ad) && string.IsNullOrEmpty(Sifre))
                {
                    return View();
                }

                ClaimsIdentity identity = null;
                bool isAuthenticate = false;
                var user = manager.GetByFilter(x => x.KullaniciAdi == Ad && x.Sifre == Sifre);
                if (user is not null)
                {
                    @ViewBag.f = 0;

                    identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,user.KullaniciAdi),
                    new Claim(ClaimTypes.Role,user.role),
                    
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
                if (isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            catch
            {

            }
            return View();
        }
        
        public async Task<IActionResult> LogOut()
        {
            

            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.hata = 1;
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            //kullanıcı adı kullanılıyorsa hata vermesi için scripte değer gönderiyorum.
            //not: 0 gönderince script düzgün çalışmadı 
            ViewBag.hata = 1;
            var control = manager.GetByFilter(x=>x.KullaniciAdi==user.KullaniciAdi);
            if (control == null)
            {
                user.role = "User";
                user.KullaniciResim = "Default.jpeg";
                manager.Add(user);
                return RedirectToAction("Login", "Account");
            }
            else
            {

                ViewBag.hata = 0;
                
            }

            return View();

        }

    }
}
