using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SBD.Models
{
    public class Pilot
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        [Key]
        public int id_pilota { get; set; }
        public LiniaLotnicza linia { get; set; }

        public virtual ICollection<PilotLot> Loty { get; set; }
        public virtual ICollection<Licencja> Licencje { get; set; }
    }
}
