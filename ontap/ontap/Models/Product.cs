using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ontap.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Vui long nhap Name")]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Nhap mo ta")]
        [StringLength(300)]
        public string? ProductDescription { get; set; }
        [Range(0,10000, ErrorMessage ="Gia phai > 0 va < 10000")]
        public decimal ProductPrice { get; set; }
        //Froeign key khoa ngoai
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //Thuoc tinh dieu huong
        public Category? Category { get; set; }
    }
}
