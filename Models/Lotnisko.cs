using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Lotnisko
    {
        [Key]
        [Display(Name = "ID")]
        public int id_lotniska { get; set; }
        [Display(Name = "Ilość miejsc")]
        public int ilosc_miejsc { get; set; }
        [Display(Name = "Miasto")]
        public string lokalizacja { get; set; }
        [Display(Name = "Nazwa lotniska")]
        public string nazwa { get; set; }

        [ForeignKey("id_lotniska")]
        public virtual ICollection<Pracownik> Pracownicy { get; set; }

        [ForeignKey("id_lotniska_startowego")]

        public virtual ICollection<Lot> Odloty { get; set; }

        [ForeignKey("id_lotniska_koncowego")]

        public virtual ICollection<Lot> Przyloty{ get; set; }
    }
}
