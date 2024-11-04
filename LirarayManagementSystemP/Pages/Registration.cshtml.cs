using LibrarayManagementSystem.Entities;
using LibraryManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LirarayManagementSystemP.Pages
{
    public class RegistrationModel : PageModel
    {
        
        public async Task<IActionResult> OnPost()
        {
            var DBContext = new LibraryContext();

            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            long mobile = Convert.ToInt64(Request.Form["phone"]);
            int employee_id = Convert.ToInt32(Request.Form["employeeId"]);
            DateTime date = Convert.ToDateTime(Request.Form["dob"]);
            //DateOnly date_of_birth = DateOnly.FromDateTime(date);
            
            string address = Request.Form["address"];

            var AdminEntry = new Admin { Full_Name = name, Email = email, Password = password, Mobile = mobile, Employee_Id=employee_id,Date_of_Birth = date, Address = address };

            DBContext.Admins.Add(AdminEntry);
            await DBContext.SaveChangesAsync();
            return RedirectToPage("/Login");

            
            

        }
        
    }
}
