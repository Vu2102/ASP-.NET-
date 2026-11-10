using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ontap.Data;
using ontap.Models;

namespace ontap.Controllers
{
    public class ProductController : Controller
    {
        public readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        // GET: ProductController
        [HttpGet]
        public ActionResult Index(string? searchString)
        {
            var data = from p in SeedData.Products
                       join c in SeedData.Categoris on p.CategoryId equals c.CategoryId
                       select new ProductViewModel
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           ProductDescription = p.ProductDescription,
                           ProductPrice = p.ProductPrice,
                           CategoryName = c.CategoryName
                       };
            var products = SeedData.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(p => p.ProductName !=null && p.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return View(data.ToList()); ;
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            _logger.LogInformation("ProductController - Details action called with id: {Id}", id);
            var product = SeedData.Products.FirstOrDefault(p => p.ProductId == id);
            var category = SeedData.Categoris.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            var ProduclViewModel = new Models.ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                CategoryName = category.CategoryName
            };
            
            return View(ProduclViewModel);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(SeedData.Categoris, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                newProduct.ProductId = SeedData.Products.Count + 1;
                SeedData.Products.Add(newProduct);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(SeedData.Categoris, "CategoryId", "CategoryName", newProduct.CategoryId);
            return View(newProduct);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.ProductId == id);
            if(product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(SeedData.Categoris, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Product editProduct)
        {
            if (ModelState.IsValid)
            {
                var product = SeedData.Products.FirstOrDefault(p => p.ProductId == editProduct.ProductId);
                if(product == null)
                {
                    return NotFound();
                }
                product.ProductName = editProduct.ProductName;
                product.ProductDescription = editProduct.ProductDescription;
                product.ProductPrice = editProduct.ProductPrice;
                return RedirectToAction(nameof(Index));
            }
            return View(editProduct);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            var category = SeedData.Categoris.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            ViewBag.CategoryName = category?.CategoryName;
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = SeedData.Products.FirstOrDefault(p => p.ProductId == id);
            if(product == null)
            {
                return NotFound();
            }
            SeedData.Products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
