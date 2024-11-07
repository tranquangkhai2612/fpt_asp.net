using DemoAuth.Models;
using DemoAuth.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAuth.Controllers
{
    public class AccountController : Controller
    {
        DemoLoginContext db;
        SecurityManager securityManager = new SecurityManager();

        public AccountController(DemoLoginContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = await ProcessLogin(username, password);
            if (account == null)
            {
                ViewBag.error = "Invalid username, password";
                return View("Index");
            }
            else
            {
                await securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("Welcome");
            }
        }

        [NonAction]
        public async Task<Account> ProcessLogin(string username, string password)
        {
            var account = await db.Accounts.Include(a => a.AccountRoles)
                .ThenInclude(a => a.Role).SingleOrDefaultAsync(a => a.Username == username && a.Enable == true);
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }

            return null;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await securityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }
    }
}
