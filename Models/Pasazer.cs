using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Pasazer
    {
        [Key]
        [Display(Name = "ID")]
        public int id_pasazera { get; set; }
        [Display(Name = "Imię")]
        public string imie { get; set; }
        [Display(Name = "Nazwisko")]
        public string nazwisko { get; set; }

        [ForeignKey("id_pasazera")]  //must add to map bilet.id_pasazera to this.id_pasazera
        public virtual ICollection<Bilet> Bilety { get; set; }

    }
}
