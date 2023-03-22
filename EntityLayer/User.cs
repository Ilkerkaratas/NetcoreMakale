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

        [StringLength(15,ErrorMessage ="Kullanýcý adý maksimum 15 karakterden oluþabilir !!")]
        [MinLength(8,ErrorMessage ="Kullanýcý adý minimum 8 karakterden oluþmalý !!")]
        [Required(ErrorMessage = "Bu alan boþ geçilemez")]
        public string KullaniciAdi { get; set; }

        public string KullaniciResim { get; set; }

        [StringLength(20,ErrorMessage ="Þifre maksimim 20 karakterden oluþabilir !!")]
        [MinLength(10,ErrorMessage ="Þifre minimum 10 karakterden oluþmalý!!")]
        [Required(ErrorMessage ="Bu alan boþ geçilemez")]
        public string Sifre { get; set; }
        public string role { get; set; }
       
    }
}
