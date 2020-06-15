using OA.Entitys.OaAuthDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.MVC.Models
{
    public class LoginViewModel
    {

        public static ClaimsPrincipal MakePrincipal(AuthUsers user,List<AuthRoles> roles,string scheme)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Account),
                new Claim(ClaimTypes.GivenName, user.DisplayName),
                new Claim(ClaimTypes.Sid, user.Uid),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Expired, user.CreateTime.ToString()),
            };
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Rolename));
            }
            var claimsIdentity = new ClaimsIdentity(claims, scheme);
            return new ClaimsPrincipal(claimsIdentity);
        }

    }
    public class LoginInputModel
    {
        public string Account { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
    public class RegisterInputModel
    {
        public string UID { get; set; }
        public string DisplayName { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ForgotInputModel
    {
        public string Account { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public class ChangePassInputModel
    {
        public string UID { get; set; }
        public string Password { get; set; }
    }
}
