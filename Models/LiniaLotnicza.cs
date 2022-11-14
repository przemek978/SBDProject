using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class LiniaLotnicza
    {
        [Key]
        public string kod { get; set; }
        public string nazwa { get; set; }

        public virtual ICollection<Samolot> Samoloty { get; set; }
    }
}
