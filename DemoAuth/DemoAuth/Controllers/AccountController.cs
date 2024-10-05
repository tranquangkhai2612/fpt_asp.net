using DemoAuth.Models;
using DemoAuth.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAuth.Controllers
{
    public class AccountController : Controller
    {
        DemoLoginContext db;
        SecurityManager securityManager;

        public AccountController(DemoLoginContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<Account> ProcessLogin(string username, string password)
        {
            var account = await db.Accounts.Include(a => a.AccountRoles)
                .ThenInclude(a => a.Role).SingleOrDefaultAsync(a=>a.Username == username && a.Enable == true);
            if (account != null) {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password)) { 
                    return account;
                }
            }

            return null;
    }
}
