using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Lotnisko
    {
        [Key]
        public int id_lotniska { get; set; }
        public int ilosc_miejsc { get; set; }
        public string lokalizacja { get; set; }
        public string nazwa { get; set; }

        [ForeignKey("id_lotniska")]
        public virtual ICollection<Pracownik> Pracownicy { get; set; }

        [ForeignKey("id_lotniska_startowego")]

        public virtual ICollection<Lot> Odloty { get; set; }

        [ForeignKey("id_lotniska_koncowego")]

        public virtual ICollection<Lot> Przyloty{ get; set; }
    }
}
