using LibrarayManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LirarayManagementSystemP.Pages
{
    

    public class BookModel : PageModel
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
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
            else
            {
                var DBContext = new LibraryContext();
                //int id = LibraryManager.Instance.GetNextBookId();
                string title = Request.Form["title"];
                string author = Request.Form["author"];
                int isbn = Convert.ToInt32(Request.Form["isbn"]);
                //DateTime DateCreated = DateTime.Now;
                int rackId = Convert.ToInt32(Request.Form["rackId"]);

                var newBook = new Book { Title = title, Author = author, DateCreated = DateTime.UtcNow, Isbn = isbn, RackId = rackId };
                DBContext.Books.Add(newBook);
                DBContext.SaveChanges();
                return RedirectToPage("/ViewBooks");
            }
            
        }

    }
}
