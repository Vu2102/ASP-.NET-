using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buoi6.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 200 characters.")]
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
