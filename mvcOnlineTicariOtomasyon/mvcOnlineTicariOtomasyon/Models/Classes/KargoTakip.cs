using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime tarihzaman { get; set; }
    }
}