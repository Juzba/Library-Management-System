using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Pages.BooksSeznam
{
    public class SeznamModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SeznamModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchText { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string SearchBy { get; set; } = "";
        public IList<Book> Book { get; set; } = default!;
        static int lastId = 0;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            SearchText ??= "";
            if (id is not null) lastId = id.Value;

            switch (SearchBy)
            {
                case ("1"):
                    Book = await _context.Books.Where(p => p.Title.Contains(SearchText)).ToListAsync();
                    break;
                case ("2"):
                    Book = await _context.Books.Where(p => p.Id.ToString().Contains(SearchText)).ToListAsync();
                    break;
                case ("3"):
                    Book = await _context.Books.Where(p => p.Author.Contains(SearchText)).ToListAsync();
                    break;
                case ("4"):
                    Book = await _context.Books.Where(p => p.YearPublished.ToString().Contains(SearchText)).ToListAsync();
                    break;
                case ("5"):
                    Book = await _context.Books.Where(p => p.Genre.Contains(SearchText)).ToListAsync();
                    break;
                default:
                    Book = await _context.Books.Where(p => p.Title.Contains(SearchText)).ToListAsync();
                    break;
            }

            switch (lastId)
            {
                case (0):
                    Book = [.. Book.OrderBy(p => p.Id)];
                    break;
                case (1):
                    Book = [.. Book.OrderBy(p => p.Title)];
                    break;
                case (2):
                    Book = [.. Book.OrderBy(p => p.Author)];
                    break;
                case (3):
                    Book = [.. Book.OrderBy(p => p.YearPublished)];
                    break;
                case (4):
                    Book = [.. Book.OrderBy(p => p.Genre)];
                    break;
                default:
                    break;
            }

            
            return Page();
        }
    }
}
