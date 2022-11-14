using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Pracownik
    {
        [Key]
        public int id_pracownika { get; set; }
        public int id_lotniska { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string stanowisko { get; set; }

        public virtual Lotnisko Lotnisko { get; set; }

    }
}
