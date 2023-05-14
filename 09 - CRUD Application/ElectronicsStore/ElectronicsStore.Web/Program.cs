using ElectronicsStore.Business.Services;
using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.DAL.Repositories;
using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.DAL.UnitOfWork;
using ElectronicsStore.DAL.UnitOfWork.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductsRepository, MockProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IUnitOfWork, MockUnitOfWork>();

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
