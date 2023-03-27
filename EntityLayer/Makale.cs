
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityLayer
{
  
    [Table("Makale")]
    public partial class Makale
    {
        [Key]
        
        public int MakaleID { get; set; }
        
        public int _Like { get; set; }

        [MaxLength(20,ErrorMessage ="Makale başlığı maksimum 20 karakter olmalıdır !!")]
        [MinLength(5,ErrorMessage ="Makale başlığı minium 5 karakter olmalıdır !!")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string MakaleBaşlik { get; set; }
        public string MakaleResim { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(150,ErrorMessage ="Makale içeriği minimum 150 karakterden oluşmalıdır !!")]
        public string MakaleAciklama { get; set; }

        public bool? MakaleStatus { get; set; }

        public int? CategoryID { get; set; }
        

        public int? UserID { get; set; }
       
        
    }
}
