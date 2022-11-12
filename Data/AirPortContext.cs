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
        public AirPortContext (DbContextOptions<AirPortContext> options)
            : base(options)
        {
        }
        public DbSet<SBD.Models.Bagaz> Bagaz { get; set; }

        
    }
}
