using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Collections.Generic;
//using System.Linq;

namespace LirarayManagementSystemP.Pages
{
    public class ViewBooksModel : PageModel
    {
        //private readonly LibraryContext _dbContext;

        public List<Book> Books { get; set; } = new List<Book>();


        public  IActionResult OnGet()
        {
            if (HttpContext.Session.Get("Id")!=null)
            {
                var _dbContext = new LibraryContext();
                Books = _dbContext.Books.ToList();
                return Page();

            }
            else
            {
                return RedirectToPage("Login");
            }
            

        }

        public async Task<IActionResult> OnPostRemoveBook(int bookId)
        {
            var _dbContext = new LibraryContext();

            var bookToRemove = await _dbContext.Books.FindAsync(bookId);
            if (bookToRemove != null)
            {
                _dbContext.Books.Remove(bookToRemove);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "Book removed successfully.";
            }
            else
            {
                TempData["Error"] = "Error removing book. Book not found.";
            }
            return RedirectToPage();
        }
    }
}
