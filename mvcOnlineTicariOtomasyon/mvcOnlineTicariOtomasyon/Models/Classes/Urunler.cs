using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName="VarChar")]
        [StringLength(30)]
        public string UrunAdi { get; set; }
     
        public short Stok { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public decimal AlisFiyati { get; set; } 
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareketi>  SatisHareketis { get; set; }

    }
}