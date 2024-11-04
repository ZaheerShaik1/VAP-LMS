
using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LirarayManagementSystemP.Pages
{
    public class VerifyOtpModel : PageModel
    {
        [BindProperty]
        public int Otp { get; set; }

        public void OnGet()
        {
            Otp = GenerateOtp();
            HttpContext.Session.SetInt32("GeneratedOtp", Otp);
            Console.WriteLine($"Generated OTP: {Otp}");
        }

        public int GenerateOtp()
        {
            Random random = new Random();
            return random.Next(10000, 999999);
        }

        public IActionResult OnPost()
        {
            var DBContext = new LibraryContext();
            var generatedOtp = HttpContext.Session.GetInt32("GeneratedOtp");
            var enteredOtp = Convert.ToInt32(Request.Form["otp"]);
            Console.WriteLine($"Entered OTP: {Otp}");

            if (generatedOtp.HasValue && enteredOtp == generatedOtp.Value)
            {
                

                string userId = "";
                HttpContext.Session.SetString("Id", userId); 
                Console.WriteLine("OTP validation successful.");
                return RedirectToPage("Index");
            }
            else
            {
                Console.WriteLine("OTP validation failed.");
                ModelState.AddModelError("", "Invalid OTP. Please try again.");
            }

            return Page(); 
        }
    }
}
