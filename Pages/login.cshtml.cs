using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SBD.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;

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
			string query = "SELECT nazwa_uzytkownika, haslo FROM pracownik";
			using (SqlCommand command = new SqlCommand(query))
			{
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						if (user.nazwa_uzytkownika == reader.GetString(0) && user.haslo == reader.GetString(1))
							return true;
					}
				}
			}
			return false;

		}
		public void OnGet()
		{
		}
	}
}
