using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Lot
    {
        [Key]
        public int id_lotu { get; set; }
        public DateTime data { get; set; }
        public int id_lotniska_startowego { get; set; }
        public int id_lotniska_koncowego { get; set; }

        public int id_samolotu { get; set; }
        public virtual Samolot Samolot { get; set; }


        //public virtual Lotnisko Lotnisko_Startowe { get; set; }
        //public virtual Lotnisko Lotnisko_Koncowe { get; set; }

        public virtual ICollection<PilotLot> Piloci { get; set; }

        public virtual ICollection<Bilet> Bilety { get; set; }
    }
}
