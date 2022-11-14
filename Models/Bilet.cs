using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Bilet
    {
    
        [Key]
        public int id_biletu { get; set; }

        public int id_pasazera { get; set; }
        public virtual Pasazer Pasazer { get; set; }

        public int id_lotu { get; set; }
        public virtual Lot Lot { get; set; }

        public int id_bagazu { get; set; }
        public virtual Bagaz Bagaz { get; set; }
        

    }
}
