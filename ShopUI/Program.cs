using Microsoft.EntityFrameworkCore;
using ShopUI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDBContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute("Pagination", "/{controller=home}/{action=index}/{category}/Page{PageNumber}");
        endpoints.MapControllerRoute("Pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
        endpoints.MapControllerRoute("Pagination", "/{controller=home}/{action=index}/{category}");
        endpoints.MapDefaultControllerRoute();
    });


app.Run();
