using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        public virtual Lotnisko Lotnisko { get; set; }
        public virtual Lotnisko Lotnisko_Koncowe { get; set; }

        [ForeignKey("id_lotu")]
        public virtual ICollection<PilotLot> Piloci { get; set; }
        [ForeignKey("id_lotu")]           ////must add to map bilet.id_lotu to this.id_lotu

        public virtual ICollection<Bilet> Bilety { get; set; }
    }
}
