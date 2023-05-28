using ElectronicsStore.Business.Services;
using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.DAL.Context;
using ElectronicsStore.DAL.Repositories;
using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.DAL.UnitOfWork;
using ElectronicsStore.DAL.UnitOfWork.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IProductsRepository, MockProductsRepository>();
builder.Services.AddScoped<IProductsRepository, EFProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
//builder.Services.AddScoped<IUnitOfWork, MockUnitOfWork>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductsStoreConnection"], b => b.MigrationsAssembly("ElectronicsStore.Web"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
