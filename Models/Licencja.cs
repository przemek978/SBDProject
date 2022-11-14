using System;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Licencja
    {
        [Key]
        public int id_licencji { get; set; }
        public DateTime data_wydania { get; set; }
        public string rodzaj_licencji { get; set; }

        public int id_pilota { get; set; }
        public virtual Pilot Pilot { get; set; }
    }
}
