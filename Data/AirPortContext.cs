using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public DbSet<SBD.Models.Bilet> Bilet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bagaz>().ToTable("BAGAZ");
            modelBuilder.Entity<Bilet>().ToTable("BILET");
            modelBuilder.Entity<Licencja>().ToTable("LICENCJA");
            modelBuilder.Entity<Lotnisko>().ToTable("LOTNISKO");
            modelBuilder.Entity<Lot>().ToTable("LOT");
            modelBuilder.Entity<PilotLot>().ToTable("ProductCategory");
            modelBuilder.Entity<Pasazer>().ToTable("PASAZER");
            modelBuilder.Entity<Bagaz>()
            .HasOne(b => b.Bilet)
            .WithOne(i => i.Bagaz)
            .HasForeignKey<Bilet>(b => b.id_bagazu);
        

            modelBuilder.Entity<PilotLot>().HasKey(c => new { c.id_pilota, c.id_lotu });
            modelBuilder.Entity<PilotLot>().HasOne(tc => tc.Pilot)
                .WithMany(t => t.Loty)
                .HasForeignKey(b => b.id_pilota).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PilotLot>().HasOne(pc => pc.Lot)
                .WithMany(c => c.Piloci)
                .HasForeignKey(b => b.id_lotu).OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<SBD.Models.Pasazer> Pasazer { get; set; }
        public DbSet<SBD.Models.Lot> Lot { get; set; }
    }
}
