using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(6)]

        public string FaturaSıraNo { get; set; }
        
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        //[Column(TypeName = "VarChar")]
        //[StringLength(30)]

        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }



        [Column(TypeName = "VarChar")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }
     
        public DateTime FaturaTarih { get; set; }

        public decimal FaturaToplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}