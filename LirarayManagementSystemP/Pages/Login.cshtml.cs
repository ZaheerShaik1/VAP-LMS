using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LirarayManagementSystemP.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var DBContext = new LibraryContext();

            long mobile = Convert.ToInt64(Request.Form["mobile"]);
            string password = Request.Form["password"];


            var admin = DBContext.Admins.FirstOrDefault(a=> a.Mobile.Equals(mobile));

            if(admin != null && admin.Password==password)
            {
                return RedirectToPage("VerifyOtp");
            }
            else
            {
                return RedirectToPage();
            }

        }
    }
}
