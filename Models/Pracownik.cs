using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Pracownik:User
    {
        [Key]
        public int id_pracownika { get; set; }
        public int id_lotniska { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string stanowisko { get; set; }
        //public string nazwa_uzytkownika { get; set; }
        //public string haslo { get; set; }

        public virtual Lotnisko Lotnisko { get; set; }

    }
}
