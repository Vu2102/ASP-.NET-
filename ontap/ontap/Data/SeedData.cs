using ontap.Models;

namespace ontap.Data
{
    public class SeedData
    {
        public static List<Category> Categoris = new List<Category>
        { 
            new Category { CategoryId = 1, CategoryName = "Electronics", CategoryDescription = "Hang dien tu" },
            new Category { CategoryId = 2, CategoryName = "Book", CategoryDescription = "Sach" },
        };

        public static List<Product> Products = new List<Product>
        { 
            new Product { ProductId = 1, ProductName = "Laptop", ProductDescription = "May tinh xach tay", ProductPrice = 1000m, CategoryId = 1 },
            new Product { ProductId = 2, ProductName = "Camare", ProductDescription = "May anh", ProductPrice = 900m, CategoryId = 1 },
            new Product { ProductId = 3, ProductName = "StoryBook", ProductDescription = "Truyen", ProductPrice = 5.99m, CategoryId = 2 },
            new Product { ProductId = 4, ProductName = "TextBook", ProductDescription = "Sach giao khoa", ProductPrice = 15.99m, CategoryId = 2 }
        };
    }
}
