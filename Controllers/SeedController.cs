using Fl_web.Data;
using Fl_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fl_web.Controllers
{
    [Route("seed")]
    public class SeedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("add-tulip")]
        public IActionResult AddTulip()
        {
            // 1. Ensure category exists
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == 2);

            if (category == null)
            {
                category = new CategoryModel
                {
                    Name = "Bukiey kwiatowe",
                    Description = "Gotowe kompozycje kwiatowe"
                };

                _context.Categories.Add(category);
                _context.SaveChanges(); // This will generate a real CategoryId
            }

            // 2. Now create the product with the VALID CategoryId
            if (!_context.Products.Any(p => p.Name == "Tulpan 30 tulipanów"))
            {
                var tulipProduct = new ProductModel
                {
                    Name = "Tulpan 30 tulipanów",
                    Description = "Piękny bukit 30 świeżych tulipanów w różnych kolorach",
                    Price = 200,
                    Stock = 10,
                    CategoryId = category.CategoryId, // Use the actual ID
                    Images = new List<ProductImageModel>
                {
                    new ProductImageModel { ImageUrl = "https://flowershopimagesbucket.s3.eu-north-1.amazonaws.com/lashomeflowers/Tulpan/Snapinst.app_482059618_18306344452230772_6056411552203644522_n_1080.jpg" },
                    new ProductImageModel { ImageUrl = "https://flowershopimagesbucket.s3.eu-north-1.amazonaws.com/lashomeflowers/Tulpan/Snapinst.app_482719135_18306977581230772_2897217928599804787_n_1080.jpg" },
                    new ProductImageModel { ImageUrl = "https://flowershopimagesbucket.s3.eu-north-1.amazonaws.com/lashomeflowers/Tulpan/Snapinst.app_482541196_18306977572230772_1129419190712288314_n_1080.jpg" },
                    new ProductImageModel { ImageUrl = "https://flowershopimagesbucket.s3.eu-north-1.amazonaws.com/lashomeflowers/Tulpan/Snapinst.app_482393834_18306977212230772_8817294393132330289_n_1080.jpg" },
                    new ProductImageModel { ImageUrl = "https://flowershopimagesbucket.s3.eu-north-1.amazonaws.com/lashomeflowers/Tulpan/Snapinst.app_482291860_18306344443230772_8981439964995980619_n_1080.jpg" }
                   
                }
                };

                _context.Products.Add(tulipProduct);
                _context.SaveChanges();
            }

            return Content("Tulip product added successfully!");
        }
    }
}
