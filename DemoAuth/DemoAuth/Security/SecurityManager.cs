using DemoAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace DemoAuth.Security
{
    public class SecurityManager
    {
        private IEnumerable<Claim> GetUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));

            account.AccountRoles.ToList().ForEach(ar =>
            {
                claims.Add(new Claim(ClaimTypes.Role, ar.Role.Name));
            });

            return claims;
        }

        public async Task SignIn(HttpContext context, Account account)
        {
            ClaimsIdentity claimsIdentity = 
                new ClaimsIdentity(GetUserClaims(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task SignOut(HttpContext context) { 
            await context.SignOutAsync();
        }
    }
}
