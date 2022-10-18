using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public ICollection<Etkinlik>? etkinlik { get; set; }
    }
}
