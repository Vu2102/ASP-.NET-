using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ontap.Data;
using ontap.Models;

namespace ontap.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        //public ActionResult Index()
        //{
        //    var Categoris = SeedData.Categoris;
        //    return View(Categoris);
        //}
        public ActionResult Index(string? searchString, string? sortOrder, int pageNumber = 1)
        {
            var data = SeedData.Categoris.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(c => c.CategoryName != null && c.CategoryName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(c => c.CategoryName);
                    break;
                case "name_asc":
                    data = data.OrderBy(c => c.CategoryName);
                    break;
                case "id_desc":
                    data = data.OrderByDescending(c => c.CategoryId);
                    break;
                case "id_asc":
                    data = data.OrderBy(c => c.CategoryId);
                    break;
                default:
                    data = data.OrderBy(c => c.CategoryId);
                    break;
            }
            int pageSize = 2; // Số sản phẩm mỗi trang
            int tong_sp = data.Count(); // Tổng số sản phẩm
            int tong_so_trang = (int)Math.Ceiling((double)tong_sp / pageSize);
            int start = (pageNumber - 1) * pageSize; // Tính vị trí bắt đầu
            var pagedData = data.Skip(start).Take(pageSize); // Lấy dữ liệu cho trang hiện tại
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = tong_so_trang;
            ViewBag.CurrentFilter = searchString;
            ViewBag.SortOrder = sortOrder;

            return View(pagedData.ToList());
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
