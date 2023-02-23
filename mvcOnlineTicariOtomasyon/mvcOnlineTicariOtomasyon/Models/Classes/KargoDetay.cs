using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        
        public int Personelid { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(25)]
        public string Alici { get; set; }
        public DateTime tarih { get; set; }

    }
}