using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace FribergCarRentals_Foxtrot.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IUser userRep;

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [BindProperty]

        public string Password { get; set; }

        public LoginModel(IUser userRep)
        {
            this.userRep = userRep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(Email, Password, out var user))
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("Email", Email);
                    HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

                    if (user.IsAdmin)
                    {
                        return RedirectToPage("/Index");
                    }

                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return RedirectToPage("/Index");
        }

        private bool IsValidUser(string username, string password, out User user)
        {
            user = userRep.GetByCredentialsAsync(username, password).Result;

            return user != null;
        }

    }
}

