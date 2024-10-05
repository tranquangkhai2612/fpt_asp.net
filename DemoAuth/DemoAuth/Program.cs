using DemoAuth.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Index";
    options.LogoutPath = "/Account/Lougout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddDbContext<DemoLoginContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddTransient<DemoLoginContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
