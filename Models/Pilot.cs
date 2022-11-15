using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Pilot
    {
        [Key]
        public int id_pilota { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }

        public LiniaLotnicza linia { get; set; }

        //[ForeignKey("id_pilota1")]
        public virtual List<Lot> Loty_Dowodcy { get; set; }
        public virtual List<Lot> Loty_Oficera { get; set; }

        [ForeignKey("id_pilota")]
        public virtual ICollection<Licencja> Licencje { get; set; }
    }
}
