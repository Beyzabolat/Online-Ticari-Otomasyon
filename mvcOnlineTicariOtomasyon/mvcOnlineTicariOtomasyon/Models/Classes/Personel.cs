using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Display(Name = "Personel Adı")]
        public string PersonelAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        [Display(Name = "Personel Soyadı")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        [Display(Name = "Personel Görsel")]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareketi> SatisHareketis { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}