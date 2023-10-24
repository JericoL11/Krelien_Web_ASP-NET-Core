using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labajo_WebApp.Pages.LoginRegister
{
    public class LoginPageModel : PageModel
    {
        public void OnGet()
        {
        }
        //Property for username and password
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }


        //funtion for login
        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "123")
            {
                return Redirect("../CrudPages");
            }

            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return Page();
            }
        }
    }
}
