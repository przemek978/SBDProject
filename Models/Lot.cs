using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class Lot
    {
        [Key]
        [Display(Name = "Lot")]
        public int id_lotu { get; set; }
        [Display(Name = "Data lotu")]
        public DateTime data { get; set; }
        public Hashtable miejsca = new Hashtable();
        [Display(Name = "Samolot")]
        public int id_samolotu { get; set; }
        public virtual Samolot Samolot { get; set; }

        [Display(Name = "Lotnisko Startowe")]
        public int id_lotniska_startowego { get; set; }
        public virtual Lotnisko Lotnisko { get; set; }
        [Display(Name = "Lotnisko końcowe")]
        public int id_lotniska_koncowego { get; set; }
        public virtual Lotnisko Lotnisko_Koncowe { get; set; }

        [Display(Name = "Kapitan samolotu")]
        public int id_kapitana {get; set; }
        public virtual Pilot Kapitan { get; set; }
        [Display(Name = "Oficer samolotu")]
        public int id_oficera { get; set; }
        public virtual Pilot Oficer { get; set; }
        [ForeignKey("id_lotu")]           ////must add to map bilet.id_lotu to this.id_lotu
        public virtual ICollection<Bilet> Bilety { get; set; }
    }
}
