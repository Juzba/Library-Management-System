using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Book
    {
        public int Id { get; set; } = 0;


        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }


        [Required(ErrorMessage = "Author is required")]
        public required string Author { get; set; }

        [Required(ErrorMessage = "YearPublished is required")]
        public DateOnly YearPublished { get; set; }


        [Required(ErrorMessage = "Genre is required")]
        public required string Genre { get; set; }
    }
}
