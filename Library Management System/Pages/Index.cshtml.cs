using Library_Management_System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Management_System.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
