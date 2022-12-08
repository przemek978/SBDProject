using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Bagaz
    {
        [Key]
        [Display(Name = "ID")]
        public int id_bagazu { get; set; }
        [Display(Name = "Waga")]
        public int waga { get; set; }
        public Bilet Bilet { get; set; }
        public Bagaz()
        {

        }
        public Bagaz(int id_bagazu, int waga)
        {
            this.id_bagazu = id_bagazu;
            this.waga = waga;
        }
    }
}
