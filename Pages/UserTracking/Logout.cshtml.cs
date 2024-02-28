using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentals_Foxtrot.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            HttpContext.Session.Clear();



            return RedirectToPage("/Index");
        }
    }
}
