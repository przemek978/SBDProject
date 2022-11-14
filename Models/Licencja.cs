using System;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Licencja
    {
        [Key]
        public int idLicencji { get; set; }
        public DateTime  dataWydania { get; set; }
        public string rodzajLicencji { get; set; }

        public int idPilota { get; set; }
        public virtual Pilot Pilot { get; set; }
    }
}
