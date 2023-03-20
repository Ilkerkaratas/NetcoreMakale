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
        [Required(ErrorMessage = "Bu alan boþ geçilemez")]

        [StringLength(20,ErrorMessage ="Kategori adý maksimim 20 karakter olmalýdýr !!")]
        [MinLength(3,ErrorMessage ="kategori adý minimum 3 karakterden oluþmalýdýr !!")]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public bool? CategoryStatus { get; set; }
        
    }
}
