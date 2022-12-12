using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Samolot
    {
        [Key]
        [Display(Name = "ID")]
        public int id_samolotu { set; get; }
        [Display(Name = "Model samolotu")]
        public string model { set; get; }
        [Display(Name = "Typ")]
        public string typ { set; get; }
        [Display(Name = "Ilość miejsc")]
        public int ilosc_miejsc { set; get; }
        [Display(Name = "Linia lotnicza")]
        public string kod_linii { get; set; }
        public LiniaLotnicza LiniaLotnicza { get; set; }

        [ForeignKey("id_samolotu")]
        public virtual ICollection<Lot> Loty { get; set; }

        public int pobierz_ilosc_miejsc()
        {
            return this.ilosc_miejsc;
        }
    }
}
