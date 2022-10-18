using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        [Required]
        public string KullaniciRegisterID { get; set; }
        
        public string KullaniciAd { get; set; }
        
        public string KullaniciSoyad { get; set; }
        
        public string KullaniciMail { get; set; }
        [Required]
        [MinLength(8)]
        public string KullaniciSifre { get; set; }
        
        [Range(1,150)]
        public int KullaniciYas { get; set; }
        public KullaniciRol? kullaniciRol { get; set; }
        public ICollection<Etkinlik>? etkinlik { get; set; }
    }
}
