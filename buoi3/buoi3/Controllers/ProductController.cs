using buoi3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace buoi3.Controllers
{
    public class ProductController : Controller
    {
        //Gia lap csdl
        public static List<Models.Product> products = new List<Models.Product>()
        {
            new Models.Product() {Id = 1, Name = "Laptop Dell", Price =1000, Description = "aaaa" },
            new Models.Product() {Id = 2, Name = "Phone Samsung"},
            new Models.Product() {Id = 3, Name = "Tablet Apple"}
        };

        // GET: ProductController
        [HttpGet]
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditProduct = products.FirstOrDefault(p => p.Id == id);
            if (EditProduct == null )
            {
                return NotFound();
            }
            return View(EditProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if(existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            product.Name = product.Name;
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
