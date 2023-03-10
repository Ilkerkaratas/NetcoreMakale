using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
