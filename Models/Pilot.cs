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

        public string kod_linii { get; set; }
        public LiniaLotnicza linia { get; set; }

        public string nazwa_uzytkownika { get; set; }
        public string haslo { get; set; }  

        public virtual List<Lot> Loty_Kapitana { get; set; }
        public virtual List<Lot> Loty_Oficera { get; set; }

        [ForeignKey("id_pilota")]
        public virtual ICollection<Licencja> Licencje { get; set; }
    }
}
