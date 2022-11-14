using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBD.Models;

namespace SBD.Data
{
    public class AirPortContext : DbContext
    {
        public AirPortContext(DbContextOptions<AirPortContext> options)
            : base(options)
        {
        }
        public DbSet<SBD.Models.Bagaz> Bagaz { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bagaz>().ToTable("BAGAZ");
            modelBuilder.Entity<Bilet>().ToTable("BILET");
            modelBuilder.Entity<Licencja>().ToTable("LICENCJA");
            modelBuilder.Entity<Lotnisko>().ToTable("LOTNISKO");
            modelBuilder.Entity<Lot>().ToTable("LOT");
            modelBuilder.Entity<PilotLot>().ToTable("ProductCategory");
            modelBuilder.Entity<PilotLot>().HasKey(c => new { c.id_pilota, c.id_lotu });
            modelBuilder.Entity<PilotLot>().HasOne(tc => tc.Pilot)
                .WithMany(t => t.Loty)
                .HasForeignKey(b => b.id_pilota).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PilotLot>().HasOne(pc => pc.Lot)
                .WithMany(c => c.Piloci)
                .HasForeignKey(b => b.id_lotu).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Bagaz>().ToTable("BAGAZ");

        }
        public DbSet<SBD.Models.Bilet> Bilet { get; set; }
    }
}
