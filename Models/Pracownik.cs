using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Pracownik
    {
        [Key]
        public int idPracownika { get; set; }
        public int idLotniska { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string stanowisko { get; set; }

        public virtual Lotnisko Lotnisko { get; set; }

    }
}
