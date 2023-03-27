
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityLayer
{
    [Table("Like")]
    public class Like
    {
        [Key]
        public int LikeID { get; set; }
        public bool Lİke_ { get; set; }

        public int UserID { get; set; }

        public int MakaleID { get; set; }

    }
}
