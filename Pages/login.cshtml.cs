using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SBD.Models;

namespace SBD.Pages
{
    public class loginModel : PageModel
    {
		private readonly IConfiguration _configuration;
		public string Message { get; set; }
		[BindProperty]
		public User user { get; set; }
		public loginModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public bool ValidateUser(User user)
		{
			string query = "SELECT nazwa_uzytkownika, haslo FROM ";

		}
		public void OnGet()
		{
		}
	}
}
