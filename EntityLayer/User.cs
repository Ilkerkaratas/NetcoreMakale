namespace EntityLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }
        public string KullaniciResim { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }
        public string role { get; set; }
       
    }
}
