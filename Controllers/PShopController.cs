using Fl_web.Data;
using Fl_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fl_web.Controllers
{
    public class PShopController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PShopController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products
                .Include(p => p.Images)  // Load product images
                .Include(p => p.Category) // Load category data
                .ToListAsync();

            ViewData["Title"] = "Products";
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Product(int id)
        {
            var product = await _db.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductId == id); // ✅ Returns null instead of error

            if (product == null)
            {
                return NotFound(); // Return 404 page if product does not exist
            }

            return View(product);
        }

    }
}
