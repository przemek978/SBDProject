using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Bilet
    {
        [Key]
        public int idBiletu { get; set; }
        public int idBagazu { get; set; }
        public int idLotu { get; set; }
        public int idPasazera { get; set; }

        public virtual Pasazer Pasazer { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Bagaz Bagaz { get; set; }

    }
}
