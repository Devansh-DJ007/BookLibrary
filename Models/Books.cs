using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "ISBN length should be 10")]
        [StringLength(10,ErrorMessage ="ISBN length should be 10")]
        public string ISBN { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [Range(1950, 2024,ErrorMessage ="Published year range must be between 1950 and 2024")]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
