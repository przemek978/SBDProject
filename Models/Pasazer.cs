using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Pasazer
    {
        [Key]
        public int id_pasazera { get; set; }
        public string nazwisko { get; set; }
        public string imie { get; set; }

        [ForeignKey("id_pasazera")]  //must add to map bilet.id_pasazera to this.id_pasazera
        public virtual ICollection<Bilet> Bilety { get; set; }

    }
}
