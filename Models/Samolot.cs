using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Samolot
    {
        [Key]
        public int id_samolotu { set; get; }
        public string model { set; get; }
        public string typ { set; get; }
        public int ilosc_miejsc { set; get; }

        public string id_linii { get; set; }
        public virtual LiniaLotnicza LiniaLotnicza { get; set; }

        [ForeignKey("id_samolotu")]
        public virtual ICollection<Lot> Loty { get; set; }

        public int pobierz_ilosc_miejsc()
        {
            return this.ilosc_miejsc;
        }
    }
}
