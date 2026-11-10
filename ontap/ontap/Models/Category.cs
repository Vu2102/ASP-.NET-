using System.ComponentModel.DataAnnotations;

namespace ontap.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten")]
        [StringLength(100)]
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        //thuoc tinh dieu huong
        public ICollection<Product>? Products { get; set; }
    }
}
