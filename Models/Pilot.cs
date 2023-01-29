using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Pilot:User
    {
        [Key]
        [Display(Name = "ID")]
        public int id_pilota { get; set; }
        [Display(Name = "Imie")]
        public string imie { get; set; }
        [Display(Name = "Nazwisko")]
        public string nazwisko { get; set; }
        [Display(Name = "Linia lotnicza")]
        public string kod_linii { get; set; }
        public LiniaLotnicza linia { get; set; }

        public virtual List<Lot> Loty_Kapitana { get; set; }
        public virtual List<Lot> Loty_Oficera { get; set; }

        [ForeignKey("id_pilota")]
        public virtual ICollection<Licencja> Licencje { get; set; }
                
    }
}
