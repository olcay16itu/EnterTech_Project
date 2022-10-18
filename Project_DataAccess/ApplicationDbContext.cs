using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Project_DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
       
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Etkinlik> Etkinliks { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<KullaniciRol> KullaniciRols { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=Project_1; Trusted_Connection=True");
            }
        }

    }
}
