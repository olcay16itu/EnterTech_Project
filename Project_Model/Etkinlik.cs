using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model
{
    public class Etkinlik
    {
        [Key]
        public int EtkinlikID { get; set; }
        [Required]
        public string EtkinlikAdi { get; set; }
        [Required]
        public string EtkinlikYeri { get; set; }
        [Range(1, int.MaxValue,ErrorMessage ="Sayı limitine uyunuz.")]
        [Required]
        public int EtkinlikKisiLimiti { get; set; }
        [Required]
        public DateTime EtkinlikTarihi { get; set; }
        [Required]
        public bool IsTicket { get; set; }
        public ICollection<Sehir>? sehir { get; set; }
        public ICollection<Kullanici>? kullanici { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
