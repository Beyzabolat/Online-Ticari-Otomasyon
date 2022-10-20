using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama{ get; set; }

        public int Miktar { get; set; } 
        public decimal Birimfiyat { get; set; }
        public decimal Tutar { get; set; }
        public Faturalar Faturalar { get; set; }
    }
}