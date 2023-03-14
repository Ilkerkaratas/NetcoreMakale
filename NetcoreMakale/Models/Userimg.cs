using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Models
{
    public class Userimg
    {
        
        public int UserID { get; set; }
        public string KullaniciAdi { get; set; }
        public IFormFile KullaniciResim { get; set; }
        public string Sifre { get; set; }
        public string role { get; set; }
    }
}
