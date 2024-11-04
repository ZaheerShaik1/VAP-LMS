using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LirarayManagementSystemP.Pages
{
    public class ViewIssuedBooksModel : PageModel
    {
        public List<IssuedBook> IssuedBooks { get; set; }

        
        public IActionResult OnGet()
        {
            var DBContext = new LibraryContext();
            if(HttpContext.Session.Get("Id")!=null)
            {
                IssuedBooks = DBContext.IssuedBooks
                .Include(ib => ib.Book)    
                .Include(ib => ib.Student)  
                .ToList();

                return Page();

            }
            else
            {
                return RedirectToPage("Login");
            }
            
        }
        


        public IActionResult OnPostReturnBook(int issuedBookId)
        {
            var DBContext = new LibraryContext();
            var issuedBook = DBContext.IssuedBooks.Find(issuedBookId);

            if (issuedBook != null)
            {
                DBContext.IssuedBooks.Remove(issuedBook);
                DBContext.SaveChanges();
                TempData["Message"] = "Book returned successfully.";
            }
            else
            {
                TempData["Error"] = "Issued book not found.";
            }

            return RedirectToPage();
        }
    }
}
