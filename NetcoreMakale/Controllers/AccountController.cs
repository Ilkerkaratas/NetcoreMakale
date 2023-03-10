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
    public class AccountController : Controller
    {
        
       
        UserManager manager = new UserManager(new UserRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Ad, string Sifre)
        {
            if (string.IsNullOrEmpty(Ad) && string.IsNullOrEmpty(Sifre))
            {
                return RedirectToAction("Login");
            }
           
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            
            if (manager.Varmi(Ad, Sifre))
            {
                var user = manager.GetByFilter(x => x.KullaniciAdi == Ad && x.Sifre==Sifre);
                
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
            return View();
        }
        
        public async Task<IActionResult> LogOut()
        {


            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

    }
}