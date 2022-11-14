using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Bagaz
    {
        [Key]
        public decimal id_bagazu { get; set; }
        public decimal waga { get; set; }
        public Bagaz()
        {

        }
        public Bagaz(decimal id_bagazu, decimal waga)
        {
            this.id_bagazu = id_bagazu;
            this.waga = waga;
        }
    }
}
