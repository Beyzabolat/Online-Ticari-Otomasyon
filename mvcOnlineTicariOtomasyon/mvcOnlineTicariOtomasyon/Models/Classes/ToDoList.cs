using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcOnlineTicariOtomasyon.Models.Classes
{
    public class ToDoList
    {
        [Key]
        public int YapilacakID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Baslik { get; set; }
        [Column(TypeName = "Bit")]
      
        public bool Durum { get; set; }
        
    }
}