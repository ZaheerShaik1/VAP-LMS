using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LirarayManagementSystemP.Pages
{
    public class ViewStudentsModel : PageModel
    {
        public List<Student> Students { get; set; } = new List<Student>();
        
        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get("Id") != null)
            {
                var _dbContext = new LibraryContext();
                Students = _dbContext.Students.ToList();
                return Page();

            }
            else
            {
                return RedirectToPage("Login");
            }
        }
        
        public IActionResult OnPostRemoveStudent(int studentId)
        {
            var DBContext = new LibraryContext();

            var studentToRemove = DBContext.Students.FirstOrDefault(b =>b.StudentId==studentId);

            DBContext.Remove(studentToRemove);
            DBContext.SaveChanges();
            TempData["Message"] = "student removed successfully.";
            
            //else
            //{
            //    TempData["Error"] = "Error removing Student. Student not found.";
            //}
            return RedirectToPage();

        }
        
    }
}

