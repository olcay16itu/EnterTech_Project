using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model
{
    public class Sehir
    {
        [Key]
        public int SehirID { get; set; }
        public string SehirAdı { get; set; }
        public ICollection<Etkinlik>? etkinlik { get; set; }
    }
}
