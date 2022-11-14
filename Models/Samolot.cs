using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Samolot
    {
        public string model { set; get; }
public string typ { set; get; }
public int iloscMiejsc { set; get; }
[Key]
        public int idSamolotu { set; get; }

public string idLinii { get; set; }
        public virtual LiniaLotnicza LiniaLotnicza { get; set; }
        public virtual ICollection<Lot> Loty { get; set; }
    }
}
