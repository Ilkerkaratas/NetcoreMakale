namespace EntityLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Bu alan bo� ge�ilemez")]

        [StringLength(20,ErrorMessage ="Kategori ad� maksimim 20 karakter olmal�d�r !!")]
        [MinLength(3,ErrorMessage ="kategori ad� minimum 3 karakterden olu�mal�d�r !!")]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public bool? CategoryStatus { get; set; }
        
    }
}
