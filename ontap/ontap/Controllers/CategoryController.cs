using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ontap.Data;
using ontap.Models;

namespace ontap.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var Categoris = SeedData.Categoris;
            return View(Categoris);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = SeedData.Categoris.FirstOrDefault(c => c.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            var Categoris = SeedData.Categoris;
            category.CategoryId = Categoris.Count + 1;
            Categoris.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var editC = SeedData.Categoris.FirstOrDefault(c => c.CategoryId == id);
            if (editC == null)
            {
                return NotFound();
            }
            return View(editC);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            var editC = SeedData.Categoris.FirstOrDefault(c => c.CategoryId == id);
            if(editC == null)
            {
                return NotFound();
            }
            editC.CategoryName = category.CategoryName;
            editC.CategoryDescription = category.CategoryDescription;
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.Categoris.FirstOrDefault(c => c.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            SeedData.Categoris.RemoveAll(c => c.CategoryId == id);
            return RedirectToAction(nameof(Index));
        }
    }
}
