using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace EntityLayer
{
   

    [Table("User")]
    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(15,ErrorMessage ="Kullan�c� ad� maksimum 15 karakterden olu�abilir !!")]
        [MinLength(8,ErrorMessage ="Kullan�c� ad� minimum 8 karakterden olu�mal� !!")]
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez")]
        public string KullaniciAdi { get; set; }

        public string KullaniciResim { get; set; }

        [StringLength(20,ErrorMessage ="�ifre maksimim 20 karakterden olu�abilir !!")]
        [MinLength(10,ErrorMessage ="�ifre minimum 10 karakterden olu�mal�!!")]
        [Required(ErrorMessage ="Bu alan bo� ge�ilemez")]
        public string Sifre { get; set; }
        public string role { get; set; }
       
    }
}
