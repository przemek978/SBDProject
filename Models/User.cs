namespace SBD.Models
{
    public class User
    {
        public string nazwa_uzytkownika { get; set; }
        public string haslo { get; set; }
        public User(string username,string password)
        {
            this.nazwa_uzytkownika = username;
            this.haslo = password;
        }
    }
}
