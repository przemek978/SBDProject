using System;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Licencja
    {
        [Key]
        [Display(Name = "ID")]
        public int id_licencji { get; set; }
        [Display(Name = "Data wydania")]
        public DateTime data_wydania { get; set; }

        [Display(Name = "Rodzaj licencji")]
        public string rodzaj_licencji { get; set; }
        [Display(Name = "Pilot")]
        public int id_pilota { get; set; }
        public virtual Pilot Pilot { get; set; }
    }
}
