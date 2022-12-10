using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class LiniaLotnicza
    {
        [Key]
        [Display(Name = "Kod Linii")]
        public string kod { get; set; }
        [Display(Name = "Nazwa linii")]
        public string nazwa { get; set; }

        [ForeignKey("id_linii")]
        public virtual ICollection<Samolot> Samoloty { get; set; }

        [ForeignKey("kod_linii")]
        public virtual ICollection<Pilot> Piloci { get; set; }

    }
}
