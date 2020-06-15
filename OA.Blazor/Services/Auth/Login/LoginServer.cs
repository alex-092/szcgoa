using IdentityModel;
using OA.Blazor.Common.Models;
using OA.Blazor.Entity.OaAuthDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.Blazor.Services.Auth.Login
{
    public class LoginServer : ILoginServer
    {
        private oa_authContext _db;
        public LoginServer(oa_authContext db)
        {
            _db = db;
        }
        private SysUserModel MakeSysUser(AuthUsers rawuser, AuthRoles roles, List<AuthUserClaims> claimslist)
        {
            return new SysUserModel
            {
                SubjectId = rawuser.Uid,
                Username = rawuser.Account,
                Password = rawuser.Password,
                Claims =
                {
                    new Claim(JwtClaimTypes.Email,rawuser.Email),
                    new Claim(JwtClaimTypes.GivenName,rawuser.DisplayName),
                    new Claim(JwtClaimTypes.NickName,rawuser.Phone),
                    new Claim(JwtClaimTypes.Locale,roles.Rolename),
                    new Claim(JwtClaimTypes.ZoneInfo,roles.Roledescript),
                    new Claim(JwtClaimTypes.Gender,roles.Id.ToString()),
                    new Claim("mytestclaim","mytestdata"),
                }
            };
        }
        private AuthRoles FindUsersRole(string uid)
        {
            var temp = _db.AuthUserRoles.FirstOrDefault(o => o.UserId == uid);
            if (temp == null)
            {
                return new AuthRoles
                {
                    Rolename = "未获取的角色信息",
                    Roledescript = "未获取的角色信息",
                    Id = 0
                };
            }
            return _db.AuthRoles.FirstOrDefault(o => o.Id == temp.RoleId);
        }
        public SysUserModel FindByUsername(string username)
        {
            var rawuser = _db.AuthUsers.FirstOrDefault(o => o.Account == username);
            if (rawuser == null)
                return null;
            return MakeSysUser(rawuser, FindUsersRole(rawuser.Uid), null);
        }
        public SysUserModel FindByID(string uid)
        {
            var rawuser = _db.AuthUsers.FirstOrDefault(o => o.Uid == uid);
            if (rawuser == null)
                return null;
            return MakeSysUser(rawuser, FindUsersRole(rawuser.Uid), null);
        }
        //public bool ValidateAccount(string account, string password)
        //{
        //    return FindByUsername(account)?.Password.Equals(EncryptorHelper.GetSZCGPassword(password)) ?? false;
        //}
    }
}
