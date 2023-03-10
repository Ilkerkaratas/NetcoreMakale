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

        [StringLength(50)]
        public string MakaleBaşlik { get; set; }

        [Column(TypeName = "text")]
        public string MakaleAciklama { get; set; }

        public bool? MakaleStatus { get; set; }

        public int? CategoryID { get; set; }
        

        public int? UserID { get; set; }
       
        
    }
}
