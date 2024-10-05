using demo_core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// scaffold-dbcontext "Server=.\\TEW_SQLEXPRESS,1433;Database=FPT_DB;User=sa;Password=123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
builder.Services.AddDbContext<FptDbContext>((options) => {
    string? conStr = builder.Configuration.GetConnectionString("DemoConnection");
    options.UseSqlServer(conStr);
});
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
