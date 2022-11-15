using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD.Models
{
    public class LiniaLotnicza
    {
        [Key]
        public string kod { get; set; }
        public string nazwa { get; set; }

        [ForeignKey("id_linii")]
        public virtual ICollection<Samolot> Samoloty { get; set; }

        [ForeignKey("kod_linii")]
        public virtual ICollection<Pilot> Piloci { get; set; }

    }
}
