using ElectronicsStore.Business.Services;
using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.DAL.Context;
using ElectronicsStore.DAL.Repositories;
using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.DAL.UnitOfWork;
using ElectronicsStore.DAL.UnitOfWork.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ElectronicsStore.Web;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//builder.Services.AddSingleton<IProductsRepository, MockProductsRepository>();
builder.Services.AddScoped<IProductsRepository, EFProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
//builder.Services.AddScoped<IUnitOfWork, MockUnitOfWork>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductsStoreConnection"], b => b.MigrationsAssembly("ElectronicsStore.Web"));
});
builder.Services.AddDbContext<IdentityDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductsStoreConnection"]);
});


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
