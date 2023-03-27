
using System.ComponentModel.DataAnnotations;


namespace EntityLayer
{
    public class Contact
    {
        public int ContactID { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public string subject { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        [EmailAddress(ErrorMessage ="Email Adresinizin doğru formattta olduğudan emin olun...")]
        public string ContactMail { get; set; }
        [Required(ErrorMessage ="Bu alan boş geçilemez!!")]
        [MinLength(15,ErrorMessage ="Minimum 15 karakter giriniz!!")]
        public string Contacttext { get; set; }

    }
}
