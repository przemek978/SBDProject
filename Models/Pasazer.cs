using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Pasazer
    {
        [Key]
        public int idPasazera { get; set; }
        public string nazwisko { get; set; }
        public string imie { get; set; }

        public virtual ICollection<Bilet> Bilety { get; set; }

    }
}
