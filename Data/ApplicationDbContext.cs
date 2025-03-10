using Fl_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Fl_web.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; } = null!;
        public DbSet<ProductImageModel> ProductImages { get; set; } = null!;
        public DbSet<PaymentModel> Payments { get; set; } = null!;
        public DbSet<OrderDetailsModel> OrderDetails { get; set; } = null!;
        public DbSet<OrdersModel> Orders { get; set; } = null!;
        public DbSet<CategoryModel> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryModel>()
       .HasKey(c => c.CategoryId);
            // Configure one-to-many: Category -> Products
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many: Product -> ProductImages
            modelBuilder.Entity<ProductImageModel>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-many: Order -> OrderDetails
            modelBuilder.Entity<OrderDetailsModel>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure many-to-one: OrderDetail -> Product
            modelBuilder.Entity<OrderDetailsModel>()
                .HasOne(od => od.Product)
                .WithMany() // Optionally add navigation in ProductModel if needed
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-one: Order -> Payment
            modelBuilder.Entity<OrdersModel>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<PaymentModel>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            var tulipProduct = new ProductModel
            {
                Name = "Tulpan 25 tulipanów",
                Description = "Piękny bukit 25 świeżych tulipanów w różnych kolorach",
                Price = 170,
                Stock = 15,
                CategoryId = 1,
                Images = new List<ProductImageModel>
                {
                    new ProductImageModel { ImageUrl = "https://flowersstore.s3.eu-north-1.amazonaws.com/las%20home%20flowers/Tulpan/Snapinst.app_482059618_18306344452230772_6056411552203644522_n_1080.jpg?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=ASIAYQNJSR7L32KSYHU7%2F20250306%2Feu-north-1%2Fs3%2Faws4_request&X-Amz-Date=20250306T220938Z&X-Amz-Expires=300&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEO7%2F%2F%2F%2F%2F%2F%2F%2F%2F%2FwEaCmV1LW5vcnRoLTEiRjBEAiAmFa4ICf93oPnOlom5YnDsbLtcMvlNj8umdU6WijF%2FSwIgcw%2BP7y4f1mkBrv%2BD9lhyYigMxYgZ46wrLdKcVatHsKwqmQIINxAAGgw1ODUwMDgwNTgzMjciDIALyd36HFCRhfGHPir2Aa%2Bdyt2Bc8LLq9zrNZhf2jHvlliFp2HBSHyLC%2Bn0xr4At5bBdU0eYvdyLVJhKfsau%2B8eTmDyGieyk%2Bo3bu%2BL%2BnZ2pWmK0%2B0tds6BtOisc8aCosTKsduIeKNub8Ee0%2FI%2FwR5oNdbKQSOFwYI8%2F%2FeatTflwEi%2FR%2Fbd3ATpf3BC1p1yLMsHDwdH2xYjHc5MQOUhsKpt5W2I64l6KuBwsEpAq5hj4%2Fquy5moQy%2BqBi%2BCwFIvr3qgyVEYqniyPKGiO%2BffsXTuf4HmGo4f1fh5AMW9b6gjrSd0YdyANzvx7AlL2NVHASd7v3K1AlX9q4bFzClLOEF9mArmTDDQp6i%2BBjrgAeaD7LhOrQoyE1woSdH8QKVwH%2FyjKz7UU5wQ8ffioM%2FevyBh1szPi4oR5Tso7lycw5n5hXZgRWa6VZ%2FllPt4GkvOzRpYtkiv1VK8EMgqdNJvIskMGJAZIW6rSUqO2ske5bHzbg2%2BM3aSw6588HdIXoUeIYQWGD75BonY8wJdP5KhVRjXBrPPb1Fh6HfX4w0tt6YwgwjjthM%2FmbCNaGtKeoYM%2Ba2N%2Fj2bDAPinuCyrWiNRl9A%2FoE1GttP9DFJcspwLsoFpPxRzm9xwpbpu4ja4VwmcqWYsz2hl203sXqfoaEP&X-Amz-Signature=020f6b5f15446b8095c8fe5511fdd602605efb875665ac8fb487413ae25654f0&X-Amz-SignedHeaders=host&response-content-disposition=inline" },
                    new ProductImageModel { ImageUrl = "https://flowersstore.s3.eu-north-1.amazonaws.com/las%20home%20flowers/Tulpan/Snapinst.app_482291860_18306344443230772_8981439964995980619_n_1080.jpg?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=ASIAYQNJSR7L3YKKORL5%2F20250306%2Feu-north-1%2Fs3%2Faws4_request&X-Amz-Date=20250306T221315Z&X-Amz-Expires=300&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEO7%2F%2F%2F%2F%2F%2F%2F%2F%2F%2FwEaCmV1LW5vcnRoLTEiRzBFAiEA8JCiFLZTPh6LFiTPX5N3nLHMLdPorNXvJSBbCn9A5rsCIBw34DVFf7BT%2FULIU17z%2BrA6l9lHxLhNdwDor04sgC9ZKpkCCDcQABoMNTg1MDA4MDU4MzI3Igw4XtVcm1y3CYpHdfgq9gG0sF4uYROEsfIA2IJ9rRVZfabyiwPsA4Fl7yF3IvmRTSH7LOR5yj5yutH5G4r4DRkXFM%2FIV6jlNjEK2eKWvYYzFNpzrjx2n%2FYL4bDp1UsL0V4SxgxCNM5lNz62iMTjYEbx%2B4DFaFHFVKkZOyXwxTEW0h3ezpcGYVbzzE99zshYPyRCWVqkz4K2HqvOnTgLBwgx7MWWU1PFGlOzQetmiSFqqELbfj2c63Mff4AyW7LExObi4IR%2FBsabOL8zFGDHdQL1jXlxJOSl4OiQCawoem0sfTEq1gtjcnIgVgDU3XxZNlFFc7U4uC3fsbaZPPAAe2z6pEvYNBIw0KeovgY63wGdLkWyYFfC1o2aBNTcr90uFkjtVpYG1jtVqTUqMC%2BdN5L%2FY3uJaXCjrPh5SRQd0e6eMN2D%2FneqNkMMc%2BHxPby%2FfnCqrXs8LGMZGipBDGBJgGYbcGgYhmiR2A4r5wEAoRFwOFcBLswjKHPC3uL3uBJn25OVdMh%2FCFTn3lEy6gdHJAEsCP1DnOArSmxln4qHU1I0jsjR1q6YaaCwhktOlRcWeQqY9wl0Am1JVwuhtdE5A1jZSzihQgeD8mHM2qVUj8UkLP8Gzrp13MF6IfL0KkjjVnfMrZqW3bZbe2nqLz8D&X-Amz-Signature=d4a688863914d8e5426e28c7249d0f72e8c536d6a8df433aff302217ecb0ccd7&X-Amz-SignedHeaders=host&response-content-disposition=inline" },
                    new ProductImageModel { ImageUrl = "https://flowersstore.s3.eu-north-1.amazonaws.com/las%20home%20flowers/Tulpan/Snapinst.app_482541196_18306977572230772_1129419190712288314_n_1080.jpg?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=ASIAYQNJSR7LU26Y7W5C%2F20250306%2Feu-north-1%2Fs3%2Faws4_request&X-Amz-Date=20250306T221339Z&X-Amz-Expires=300&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEO7%2F%2F%2F%2F%2F%2F%2F%2F%2F%2FwEaCmV1LW5vcnRoLTEiRjBEAiAoLUJpkH5thiL7avKM1%2F6v4yxyWpPhAvjy4s4JkEjPNQIgLNPl2DISJb9NTamvlfr3VCUI10KueOLaG%2FF4D9RJQYEqmQIINxAAGgw1ODUwMDgwNTgzMjciDH2ZR0t%2BAG1yYCpj9Sr2AYDgIY0stJuY6TN1URaVl1XghvDNY5f3xpdWWCqqfCCwtPQMHGigX6H443fxHmi8S9ZgW2DhVQ0JQ2MzcYPHlg0tRm8M69aycp3BkVMO2KqQ5toKjO%2FtTzl%2BAuxrr%2BuUk59Nm4eEyN8TEQnPVyWYBaBOc6O2JKUQtNgeJxnhLnq7ZXrpzJRYmMiCJkqRNv8G2ebE9yJ3lffrGozCh5LGy%2FigO5SKAZsnQM3LWlMlkWZz7ulE9vBtQBhfpR%2FTy1kpzyGizLkfV4lEsZPl7vjfZRTTH4yE3URXO%2FjXhQfj%2Fzbg%2FT%2FZ5PGOkaW%2BgRHFYt1Ow97bqyAfijDQp6i%2BBjrgARv%2BUt8bnK1nJEpfalFSetjAh1TmCZo%2B9dCoIiSHO4wAHILBV3q9q4FbFVVFbntH%2BMG4%2B5OVrVZpNJ6BgwXcSq9SdNmI%2FOilGe4TIxxorjHCK7uqRQqCwKk4YeaocXmI9mJpp3fK6wHjwk3nY%2BL0PiN1u%2FJ50cRlWoIXuabBkfjJXmAO33N6g0TK3ZLusYlKjV4AcucD7vzSkx1bqy7czYKlrxkeIsAF1V7jLuYUeVdWwQep%2FkfGT5empJ2Wiu4O8v4Erv%2BwSoKi7uLWrUO8pwHvQY8UDWs%2BY1zvnTjsK0XO&X-Amz-Signature=2c3b337b6a26cd26918d843a08425c2386db0dd1c75bf0d44460b0219029d297&X-Amz-SignedHeaders=host&response-content-disposition=inline" },
                    new ProductImageModel { ImageUrl = "https://flowersstore.s3.eu-north-1.amazonaws.com/las%20home%20flowers/Tulpan/Snapinst.app_482953033_18306976504230772_3501449082510138006_n_1080.jpg?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=ASIAYQNJSR7L27BFGYFC%2F20250306%2Feu-north-1%2Fs3%2Faws4_request&X-Amz-Date=20250306T221443Z&X-Amz-Expires=300&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEO7%2F%2F%2F%2F%2F%2F%2F%2F%2F%2FwEaCmV1LW5vcnRoLTEiRzBFAiBzztZfy9xboN6O%2BMAYcHXPOUB5ojwfoh5xyf%2FVOhtXMQIhANMndyxxRS4ZD1XDgGuaC8FvU%2FnwEA2AdYotewzcFFa3KpkCCDcQABoMNTg1MDA4MDU4MzI3IgwPptsRJHFSBxVLwZ0q9gF%2FLUF7EzG6F7YtKtufSzkyIoYISXtwRdLZIz%2BH9%2BbEwetetEF2Xlw%2FCIPYoAKzWJiTRihCq%2BUlmNoDihC3JW9OHGuV85IkrxihTyr1baUHCE%2FbhwMAXN4Cz4jui5zyqbyS2dBGZkuuf6BjM%2BZPng40d%2F7wD%2BC8ENnKZ1UB0TPBvoV%2BDFFBpyZedUXbI5GnlRzcBfH3uEEqhiXgiDlPjb3%2BYWhuhPVTYD2k3B9YMZWYX9GjvIzCJLSibTBKh%2FlpkWxkKCHjCO0kWg5dypU%2Byjj4GWscgDDlqUxWBveGAo3Ilw3Q3AMiUkHCcgy2hogf1NEX6g4rtsUw0KeovgY63wH3ea40fNuNez32XQAV9t%2BgEpeLHbIF6Jx%2F0VHo3RumRfQ4RuZ%2FLntmAOne1UtclsHuueQH7t5LYSgj4L71VVJE7Hp6fpvHRlVagOKK8D3bdl3oEEb1JZmTjlynG%2BP6fkEDe2Rmgn0cPY2QeuvaU3pmGoynFrFV1ood4EEEDTfqqmcQQClj8Q20wzS4QTrj9xtW%2FORUZdJkYMUeVAdddthNlfEDCPGeeRb8Vbk%2BoIb7BviWy7UZb2XQkhL1FZZmGr45siUJRr%2FyIGbCNp1fkR8O4gZetfToieDgdD8vCitu&X-Amz-Signature=67e46286406c19737de006aa045e64a78d7787023f07ef51627cac35082b286b&X-Amz-SignedHeaders=host&response-content-disposition=inline" },

                }
            };
        }
    }
}
