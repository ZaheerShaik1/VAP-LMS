using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace LirarayManagementSystemP.Pages
{
    public class IssueBookModel : PageModel
    {
        public List<Book> AvailableBooks { get; set; }
        public List<Student> AvailableStudents { get; set; }

        public void  OnGet()
        {
            var DBContext = new LibraryContext();
            AvailableStudents = DBContext.Students.ToList();
            var issuedBookIds = DBContext.IssuedBooks.Select(ib => ib.BookId).ToList();
            AvailableBooks = DBContext.Books
                .Where(b => !issuedBookIds.Contains(b.Id))
                .ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            var DBContext = new LibraryContext();
            int bookId = Convert.ToInt32(Request.Form["bookid"]);
            int studentId = Convert.ToInt32(Request.Form["id"]);
            int duration = Convert.ToInt32(Request.Form["Duration"]);
            var issuedBook = new IssuedBook
            {
                BookId = bookId,
                StudentId = studentId,
                IssueDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(duration)
            };

            DBContext.IssuedBooks.Add(issuedBook);
            DBContext.SaveChangesAsync();

            return RedirectToPage("/ViewIssuedBooks"); 
        }
    }
}
