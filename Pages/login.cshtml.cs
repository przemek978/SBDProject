 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SBD.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SBD.Pages
{
    public class LoginModel : PageModel
    {
		private readonly IConfiguration _configuration;
		public string Message { get; set; }
		[BindProperty]
		public User user { get; set; }
		public LoginModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public bool ValidateUser(User user)
		{
			string conn = _configuration.GetConnectionString("AirPortContext");
			SqlConnection connection = new SqlConnection(conn);
			string query = "SELECT nazwa_uzytkownika, haslo FROM pracownik";
			using (SqlCommand command = new SqlCommand(query, connection))
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

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			if (ValidateUser(user))
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name, user.nazwa_uzytkownika)
				};
				var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
				await HttpContext.SignInAsync("CookieAuthentication", new
			   ClaimsPrincipal(claimsIdentity));
				return RedirectToPage(returnUrl);
			}
			return Page();
		}

		public void OnGet()
		{
		}
	}
}
