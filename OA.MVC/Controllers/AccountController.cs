
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.VisualBasic;
using OA.Entitys;
using OA.Entitys.OaAuthDB;
using OA.MVC.Common.Base;
using OA.MVC.Models;
using OA.Services.Auth.Roles;
using OA.Services.Auth.User;
using OA.Services.SysLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.MVC.Controllers
{
    public class AccountController:BaseController
    {
        private readonly IUserService _user;
        private readonly IRoleService _role;
        private readonly ISysLogService _syslog;

        public AccountController(IUserService user, IRoleService role, ISysLogService syslog)
        {
            _user = user;
            _role = role;
            _syslog = syslog;
        }
        //LoginPage
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(string.IsNullOrEmpty(ReturnUrl))
                    return Redirect("/");
                return Redirect(ReturnUrl);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                _syslog.LogoutLog(BC_ClientIP, BC_UserAccount);
                await HttpContext.SignOutAsync(ConfigStrings.SZCGOA_AuthenticationScheme);            
            }
            catch (Exception ex)
            {
                return Json(AjaxResult.Failed(ex.Message+"注销代码报错,请联系管理员"));
            }
            return Redirect("Login");
        }
        [HttpGet]
        public IActionResult RegSuccess()
        {
            return View();
        }
        
        [Route("UnAuth", Name = "UnAuthrPage")]
        [HttpGet]
        public IActionResult UnAuth()
        {
            return View();
        }
        //LoginAPI
        [HttpPost]
        public async Task<AjaxResult> LoginAsync(LoginInputModel model)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if (_user.FindByUsername(model.Account) == null)
                return AjaxResult.Failed("未找到该账号");
            if (_user.IsDeleted(model.Account))
                return AjaxResult.Failed("账户已经被删除");
            switch (_user.CheckAccountLock(model.Account))
            {
                case Entitys.BaseDataType.UserAcountLockType.NORMAL:
                    break;
                case Entitys.BaseDataType.UserAcountLockType.TOO_MANY_LOGIN:
                    return AjaxResult.Failed("账户登录次数过多,请稍后再次尝试");
                case Entitys.BaseDataType.UserAcountLockType.ADMIN_LOCK:
                    return AjaxResult.Failed("账户已经被管理员锁定,请联系系统管理员");
                case Entitys.BaseDataType.UserAcountLockType.NOT_APPROVE:
                    return AjaxResult.Failed("您的账户正在等待审核人员认证审核,审核通过后才能登录");
                case Entitys.BaseDataType.UserAcountLockType.ERROR:
                    return AjaxResult.Failed("登录发送错误,请联系管理员");
                default:
                    break;
            }

            if (_user.ValidateAccount(model.Account, model.PassWord))
            {
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    RedirectUri = this.Request.Host.Value
                };
                var user = _user.FindByUsername(model.Account);
                try
                {
                    await HttpContext.SignInAsync(ConfigStrings.SZCGOA_AuthenticationScheme,  //参数1  验证场景
                    LoginViewModel.MakePrincipal(user, _role.GetUserRolesByUserID(user.Uid), ConfigStrings.SZCGOA_AuthenticationScheme),  //参数2  验证身份信息
                    authProperties);  //参数3  验证参数
                    _user.AddLoginClue(user, BC_ClientIP, "OA.Web");
                    _syslog.LoginSuccessLog(BC_ClientIP, model.Account);
                    return AjaxResult.Success("登录成功");
                }
                catch (Exception ex)
                {
                    return AjaxResult.Failed("登录报错,请联系管理员,代号:"+ex.Message);
                }
            }
            else {
                _syslog.LoginFaildLog(BC_ClientIP, model.Account);
                return AjaxResult.Failed("账号或密码错误,请重试");
            }              
        }
        [HttpPost]
        public AjaxResult Register(RegisterInputModel model)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if (_user.RegisterAccount(model.DisplayName, model.Account, model.Phone, model.Email, model.Password))
                return AjaxResult.Success("账号注册成功");
            return AjaxResult.Failed("注册失败,请联系管理员");
        }
        [HttpPost]
        public AjaxResult Forgot(ForgotInputModel model)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            var user = _user.UserClaimAccount(model.Account, model.Phone, model.Email);
            if (user == null)
                return AjaxResult.Failed("信息验证未通过");
            return AjaxResult.Success(user.Uid);
        }
        [HttpPut]
        public AjaxResult Forgot(ChangePassInputModel model)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if (_user.UserChangePassword(_user.FindByID(model.UID), model.Password))
                return AjaxResult.Success("密码修改成功,请重新登陆");
            return AjaxResult.Failed("修改失败,请联系管理员");
        }
    }
}
