using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SBD.Models
{
    public class User
    {
		[Display(Name = "Nazwa użytkownika")]
		public string nazwa_uzytkownika { get; set; }
		[Display(Name = "Hasło")]
		[DataType(DataType.Password)]

		public string haslo { get; set; }
        //public User(string username,string password)
        //{
        //    this.nazwa_uzytkownika = username;
        //    this.haslo = password;
        //}
    }
}
