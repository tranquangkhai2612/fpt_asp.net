using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service;
using DomainLayer.Data;
using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));
builder.Services.AddScoped<ICustomService<StudentDTO>, StudentService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(ServiceLayer.Profiles.AutoMapperProfile));

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
