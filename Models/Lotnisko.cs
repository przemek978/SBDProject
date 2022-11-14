using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Lotnisko
    {
        [Key]
        public int id_lotniska { get; set; }
        public int ilosc_miejsc { get; set; }
        public string lokalizacja { get; set; }
        public string nazwa { get; set; }

        public virtual ICollection<Pracownik> Pracownicy { get; set; }
        public virtual ICollection<Lot> LotyZ { get; set; }
        public virtual ICollection<Lot> LotyDo { get; set; }
    }
}
