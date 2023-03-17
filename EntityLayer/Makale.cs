namespace EntityLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Makale")]
    public partial class Makale
    {
        [Key]
        
        public int MakaleID { get; set; }
        
        public int _Like { get; set; }

        [MaxLength(20,ErrorMessage ="Makale başlığı maksimum 20 karakter olmalıdır !!")]
        [MinLength(5,ErrorMessage ="Makale başlığı minium 5 karakter olmalıdır !!")]
        public string MakaleBaşlik { get; set; }
        public string MakaleResim { get; set; }

        
        [MinLength(150,ErrorMessage ="Makale içeriği minimum 150 karakterden oluşmalıdır !!")]
        public string MakaleAciklama { get; set; }

        public bool? MakaleStatus { get; set; }

        public int? CategoryID { get; set; }
        

        public int? UserID { get; set; }
       
        
    }
}
