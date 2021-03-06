using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineAutomationProject.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz")] 

        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="en fazla 30 karakter girebilirsiniz")]
        [Required(ErrorMessage ="bu alanı boş geçemezsiniz.")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
    }
}