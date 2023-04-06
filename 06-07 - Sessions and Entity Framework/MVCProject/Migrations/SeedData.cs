using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Migrations
{
    public static class SeedData
    {
        public static void AddInitialData(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                        new Product
                        {
                            DateAdded = DateTime.Now,
                            Name = "Guitar",
                            Description = $"Test description 1",
                            Price = 100
                        },
                        new Product
                        {
                            DateAdded = DateTime.Now,
                            Name = "Piano",
                            Description = $"Test description 2",
                            Price = 200
                        },
                        new Product
                        {
                            DateAdded = DateTime.Now,
                            Name = "Drums",
                            Description = $"Test description 3",
                            Price = 300
                        },
                        new Product
                        {
                            DateAdded = DateTime.Now,
                            Name = "Violin",
                            Description = $"Test description 4",
                            Price = 400
                        },
                        new Product
                        {
                            DateAdded = DateTime.Now,
                            Name = "Triangle",
                            Description = $"Test description 5",
                            Price = 500
                        },
                        new Product
                        {
                            DateAdded = DateTime.Now,
                            Name = "Harp",
                            Description = $"Test description 6",
                            Price = 600
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
