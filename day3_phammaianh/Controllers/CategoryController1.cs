using day3_phammaianh.Data;
using day3_phammaianh.Models;
using Microsoft.AspNetCore.Mvc;

namespace day3_phammaianh.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var _categories = SeedData.Categories;
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            //lay ra category co id truyen vao tu SeedData
            var category = SeedData.Categories.FirstOrDefault(c => c.Id == id);
            //neu category
            if (category == null)
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
        public ActionResult Create([FromForm] Models.Category category)
        {
            if (ModelState.IsValid)
            {
                //lay max id trong danh dach SeedData.Categories
                int maxId = SeedData.Categories.Max(c => c.Id);
                //set id cho category
                category.Id = maxId + 1;
                //them category vao SeedData
                SeedData.Categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var category = SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Category category)
        {
            var existingCategory = SeedData.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }
            {
                return View();
            }
        }

        /// GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var existingCategory = SeedData.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            SeedData.Categories.Remove(existingCategory);
            return RedirectToAction(nameof(Index));
        }
    }
}