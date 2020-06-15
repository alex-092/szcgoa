using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OA.Blazor.Pages.Auth
{
    [AllowAnonymous]
    public class TestLoginModel : PageModel
    {
        public string ReturnUrl { get; set; }
        public async Task<IActionResult>
        OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("~/");
            try
            {
                // ������е��ⲿCookie
                await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            // *** !!! ��������������֤�û� !!! ***
            // �ڴ�ʾ���У����ǽ���¼�û�����ʾ��ʼ�յ�¼�û���
            //
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, paramUsername),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Admin2"),
                new Claim(ClaimTypes.Sid, "dasfasd-*fads-sdaf--afd"),
                new Claim("testtype", "testmytype"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
            try
            {
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect(returnUrl);
        }
    }
}
