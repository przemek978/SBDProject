using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace SBD.Pages.Login
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnGet()
		{
			await HttpContext.SignOutAsync("CookieAuthentication");
			return this.RedirectToPage("/Index");
		}
    }
}
