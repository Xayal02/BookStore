using BookStore.Data.Persistence;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;

        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> Categories = await _dataContext.Categories.ToListAsync();
            return View(Categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.AddAsync(category);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index", "Category");

            }

            return View();
        }
    }
}
