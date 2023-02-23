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
        [Display(Name = "Cari Adı")]
        public string CariAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        [Display(Name = "Cari Soyadı")]
        public string CariSoyad { get; set; }
     
        // public string CariUnvan { get; set; } 
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        [Display(Name = "Mail")]
        public string CariMail { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string CariSifre { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        [Display(Name = "Şehir")]
        public string CariSehir { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareketi> SatisHareketis { get; set; }
      
    }
}