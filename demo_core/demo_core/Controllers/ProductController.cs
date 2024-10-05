using demo_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace demo_core.Controllers
{
    public class ProductController : Controller
    {
        FptDbContext db;

        public ProductController(FptDbContext db) { 
            this.db = db;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        public IActionResult About() { 
            return View();
        }

        public string Test(int id, int a, int b) {
            return $"Response: {id}, a={a}, b ={b}";
        }
    }
}
