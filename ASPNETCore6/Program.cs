using ASPNETCore6;
using ASPNETCore6.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConn");
builder.Services.AddDbContext<LovelyContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<LovelySPContext>(options => options.UseSqlServer(connection));
builder.Services.AddTransient<IDeptRepository, DeptRepo>();


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
