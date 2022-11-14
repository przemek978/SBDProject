using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Samolot
    {
        public string model { set; get; }
        public string typ { set; get; }
        public int ilosc_miejsc { set; get; }
        [Key]
        public int id_samolotu { set; get; }

        public string id_linii { get; set; }
        public virtual LiniaLotnicza LiniaLotnicza { get; set; }
        public virtual ICollection<Lot> Loty { get; set; }
    }
}
