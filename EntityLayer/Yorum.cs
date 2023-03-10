﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("Yorum")]
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        public string yorum_text { get; set; }

        public int UserID { get; set; }

        public int MakaleID { get; set; }

    }
}
