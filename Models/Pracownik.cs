using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Pracownik:User
    {
        [Key]
        [Display(Name = "ID")]
        public int id_pracownika { get; set; }
        [Display(Name = "Lotnisko")]
        public int id_lotniska { get; set; }
        [Display(Name = "Imie")]
        public string imie { get; set; }
        [Display(Name = "Nazwisko")]
        public string nazwisko { get; set; }

        public virtual Lotnisko Lotnisko { get; set; }

    }
}
