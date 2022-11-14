using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Lotnisko
    {
        [Key]
        public int idLotniska { get; set; }
        public int iloscMiejsc { get; set; }
        public string lokalizacja { get; set; }
        public string nazwa { get; set; }

        public virtual ICollection<Pracownik> Pracownicy { get; set; }
        public virtual ICollection<Lot> LotyZ { get; set; }
        public virtual ICollection<Lot> LotyDo { get; set; }
    }
}
