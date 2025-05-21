using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Pages
{
    public class SeznamModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SeznamModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}
