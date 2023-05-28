using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.DAL.Repositories
{
    public class MockProductsRepository : IProductsRepository
    {
        private readonly List<Product> _productsList = new()
        {
            new Product
            {
                Id = 1,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Computer",
                Brand = "Lenovo",
                ServicePrice = 2,
                ImageURL = "https://www.antec.com/images/index-update-img/index-main-block1-1-20211118.jpg"
            },
            new Product
            {
                Id = 2,
                AddDate = DateTime.Now,
                BasePrice = 20,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = false,
                Name = "Laptop",
                Brand = "HP",
                ServicePrice = 4,
                ImageURL = "https://custompcgenie.co.uk/assets/img/custompc/GX11DYN_8f9c8c12-1533-4257-89e8-d99ca3d12d9a.png"
            },
            new Product
            {
                Id = 3,
                AddDate = DateTime.Now,
                BasePrice = 300,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Brand = "Asus",
                Name = "Computer",
                ServicePrice = 30,
                ImageURL = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE55U7F"
            },
            new Product
            {
                Id = 4,
                AddDate = DateTime.Now,
                BasePrice = 25,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Adapter",
                Brand = "Asus",
                ServicePrice = 5.5m,
                ImageURL = "https://webkhoj.com/wp-content/uploads/2020/02/pc-ka-full-form-e1658055590943.jpg"
            },
            new Product
            {
                Id = 5,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "MousePad",
                ServicePrice = 2,
                ImageURL = "https://www.datocms-assets.com/34299/1678219621-player-prime-hero-primary-sm.png"
            },
            new Product
            {
                Id = 6,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Mouse",
                ServicePrice = 2,
                ImageURL = "https://www.digitalstorm.com/img/products/lumos/2020-overview-4-a.jpg"
            },
            new Product
            {
                Id = 7,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Keyboard",
                ServicePrice = 2,
                ImageURL = "https://www.yugatech.com/wp-content/uploads/2021/07/pc-build_1.jpg"
            },
            new Product
            {
                Id = 8,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Monitor",
                ServicePrice = 2,
                ImageURL = "https://www.freecodecamp.org/news/content/images/2021/11/niclas-illg-wzVQp_NRIHg-unsplash.jpg"
            },
            new Product
            {
                Id = 9,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Printer",
                ServicePrice = 2,
                ImageURL = "https://stormcomputershop.co.uk/wp-content/uploads/2021/09/IMG_3495-1.jpeg"
            },
            new Product
            {
                Id = 10,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Cooler",
                ServicePrice = 2,
                ImageURL = "https://www.newegg.com/insider/wp-content/uploads/2019/11/darkflash_dlm21_4-1024x576.jpg"
            },
            new Product
            {
                Id = 11,
                AddDate = DateTime.Now,
                BasePrice = 10,
                Description = "ლორემ იპსუმ ელიზბარ ცქმუტავდა ძვირფასთვლიანი",
                IsAvailable = true,
                Name = "Case",
                ServicePrice = 2,
                ImageURL = "https://m.media-amazon.com/images/I/41xIJfkuWCL._SL160_.jpg"
            },
        };

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Task.FromResult(_productsList.First(product => product.Id == id));
        }

        public async Task<(IQueryable<Product>, int)> ListAsync(int limit, int page, string orderby)
        {
            var products = orderby == "DESC" ? _productsList.OrderByDescending(product => product.Id) : _productsList.OrderBy(product => product.Id);
            var totalPages = Math.Ceiling((decimal)products.Count() / limit);

            return (await Task.FromResult(products.Skip(limit * (page - 1)).Take(limit).AsQueryable()), (int)totalPages);
        }

        public Task CreateProduct(Product product)
        {
            product.Id = _productsList.MaxBy(p => p.Id).Id + 1;
            product.AddDate = DateTime.Now;
            _productsList.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(int id)
        {
            _productsList.RemoveAll(product => product.Id == id);
            return Task.CompletedTask;
        }

        public Task EditProduct(Product product)
        {
            var productToUpdate = _productsList.FirstOrDefault(p => p.Id == product.Id);
            productToUpdate.ServicePrice = product.ServicePrice;
            productToUpdate.BasePrice = product.BasePrice;
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Brand = product.Brand;
            productToUpdate.ImageURL = product.ImageURL;
            productToUpdate.IsAvailable = product.IsAvailable;
            productToUpdate.ChangeDate = DateTime.Now;
            return Task.CompletedTask;
        }
    }
}