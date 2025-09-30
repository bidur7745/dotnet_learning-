using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;

        public int PublishedYear { get; set; }
    }
}
