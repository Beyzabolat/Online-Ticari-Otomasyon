using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class Cari
    { 
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage ="Karakter sınırını aştınız!")]
        public string CariAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string CariSoyad { get; set; }
     
        // public string CariUnvan { get; set; } 
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareketi> SatisHareketis { get; set; }
      
    }
}