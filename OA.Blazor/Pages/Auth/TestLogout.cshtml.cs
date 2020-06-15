using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OA.Blazor.Pages.Auth
{
    public class TestLogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // 清除现有的外部Cookie
            await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect(Url.Content("~/"));
        }
    }
}
