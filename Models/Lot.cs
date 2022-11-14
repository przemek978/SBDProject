using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Lot
    {
        public DateTime data { get; set; }
        public int idLotniskaStartowego { get; set; }
        public int idLotniskaKoncowego { get; set; }
        [Key]
        public int idLotu { get; set; }
        public int idSamolotu { get; set; }

        public virtual Samolot Samolot { get; set; }
        public virtual Lotnisko LotniskoWylotowe { get; set; }
        public virtual Lotnisko LotniskoPrzylotowe { get; set; }
        public virtual ICollection<PilotLot> Piloci { get; set; }
        public virtual ICollection<Bilet> Bilety { get; set; }
    }
}
