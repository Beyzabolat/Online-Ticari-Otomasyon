using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}