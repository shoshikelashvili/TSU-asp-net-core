using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using ProductsStore.Business.Services;
using ProductsStore.DAL.Context;
using ProductsStore.DAL.Repositories;

namespace Composition
{
    public class CompositionRoot
    {
        public static void InjectDependencies(IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<StoreDbContext>(opts =>
            {
                opts.UseSqlServer(config["ConnectionStrings:ProductsStoreConnection"], b => b.MigrationsAssembly("ProductsStore.Web"));
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ProductService>();
        }
    }
}