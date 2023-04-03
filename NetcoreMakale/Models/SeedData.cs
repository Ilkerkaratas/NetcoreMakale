using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace NetcoreMakale.Models
{
    public class SeedData
    {
        public void Seed()
        {
            using (var context = new Context())
            {

                context.Database.Migrate();
                if (!context.users.Any())
                {
                    HashPassword hashPassword = new HashPassword();
                    User user = new User();
                    user.KullaniciAdi = "Admin";
                    user.Sifre = hashPassword.Encode("Admin");
                    user.role = "Admin";
                    user.KullaniciResim = "Default.jpeg";
                    context.users.Add(user);
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    Category category = new Category();
                    category.CategoryName = "Genel";
                    category.CategoryStatus = true;
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
               

            }
        }
         
    }
}
