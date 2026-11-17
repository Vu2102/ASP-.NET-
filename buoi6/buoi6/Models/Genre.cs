using System.ComponentModel.DataAnnotations;

namespace buoi6.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string? Name { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
