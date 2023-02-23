using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Urunad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string Urunbilgi { get; set; }
    }
}