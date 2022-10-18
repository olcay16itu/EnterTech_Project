using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model
{
    public class KullaniciRol
    {
        [Key]
        public int RoleID { get; set; }
        public ICollection<Kullanici>? kullanici { get; set; }
    }
}
