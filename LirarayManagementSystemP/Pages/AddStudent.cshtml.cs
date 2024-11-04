using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LirarayManagementSystemP.Pages
{
    public class AddStudentModel : PageModel
    {
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Id") == null)
            {
                return RedirectToPage("Login"); 
            }
            return Page(); 
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetString("Id") == null)
            {
                return RedirectToPage("Login"); 
            }

            using (var DBContext = new LibraryContext())
            {
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                long mobile = Convert.ToInt64(Request.Form["mobile"]);
                int studentId = Convert.ToInt32(Request.Form["id"]);
                string department = Request.Form["Dept"];
                var newStudent = new Student{Name = name,Email = email,Mobile = mobile,StudentId = studentId,Department = department ,DateAdded = DateTime.UtcNow };
                DBContext.Students.Add(newStudent);
                DBContext.SaveChanges();
            }

            return RedirectToPage("/ViewStudents");
        }
    }
}
