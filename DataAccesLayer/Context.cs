using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    //veri tabanı ile bağlantı kurucak context sınıfım
    //Not: tablolar arası ilişkiler yapılmamasının sebebi benden öyle istenmesi.
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=İlkerMakaleDb;integrated security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Makale> makales{ get; set; }
        public DbSet<Yorum> yorums { get; set; }
        public DbSet<Like> likes { get; set; }
        public DbSet<User> users{ get; set; }


    }
}
