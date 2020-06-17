using OA.MVC.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OA.MVC.Models;
using OA.Services.Core.Menu;
using Microsoft.AspNetCore.Authorization;
using OA.Services.Auth.User;
using OA.Services.Auth.Roles;
using OA.MVC.Common.Filters;

namespace OA.MVC.Controllers
{
    [Authorize]
    //[AuthRFilter]
    public class ManageController:BaseController
    {
        private readonly IMenuService _menu;
        private readonly IUserService _user;
        private readonly IRoleService _role;

        public ManageController(IMenuService menu, IUserService user, IRoleService role)
        {
            _menu = menu;
            _user = user;
            _role = role;
        }
        // 系统菜单管理-页面
        public IActionResult SysMenu()
        {
            return View();
        }
        //菜单列表 api
        [HttpGet]
        public JsonResult MenuList(string type)
        {
            if(type=="tree")
                return Json(SysRoleViewModel.MakeMenuTreeData(_menu.GetAllMenu()));
            return Json(_menu.GetAllMenu());
        }
        //菜单项API
        [HttpPost]
        public AjaxResult MenuItem(SysMenuInputModel model)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if (_menu.AddMenu(model.Pid, model.Title, model.Icon, model.Controller, model.Action, model.MenuLevel, model.Order))
                return AjaxResult.Success("新菜单添加成功");
            return AjaxResult.Failed("菜单添加失败");
        }
        [HttpPut]
        public AjaxResult MenuItem(SysMenuInputModel model,int id)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if(id == 0)
                return AjaxResult.Failed("错误,未获取正确的参数");
            if (_menu.EditMenu(id,model.Pid, model.Title, model.Icon, model.Controller, model.Action, model.MenuLevel, model.Order))
                return AjaxResult.Success("菜单修改成功");
            return AjaxResult.Failed("菜单修改失败");
        }
        [HttpDelete]
        public AjaxResult MenuItem(int id)
        {
            if (id == 0)
                return AjaxResult.Failed("错误,未获取正确的参数");
            if(_menu.DeleteMenu(id))
                return AjaxResult.Success("菜单删除成功");
            return AjaxResult.Failed("菜单删除失败");
        }
        // SysRole角色管理 页面
        public IActionResult SysRole()
        {
            return View();
        }
        //角色列表 api
        [HttpGet]
        public JsonResult RoleList()
        {
            return Json(_role.GetAllRoles());
        }
        //角色项目 api
        [HttpPost]
        public AjaxResult RoleItem(SysRoleInputModel model)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if (_role.AddRole(model.Rolename, model.Roledescript, (sbyte)model.Level))
                return AjaxResult.Success("添加角色成功");
            return AjaxResult.Failed();
        }
        [HttpPut]
        public AjaxResult RoleItem(SysRoleInputModel model,int id)
        {
            if (!ModelState.IsValid)
                return AjaxResult.Failed(ModelState.GetFirstErrMsg());
            if (id == 0)
                return AjaxResult.Failed("错误,未获取正确的参数");
            if (_role.EditRole(model.Rolename, model.Roledescript, (sbyte)model.Level,id))
                return AjaxResult.Success("修改角色成功");
            return AjaxResult.Failed();
        }
        [HttpDelete]
        public AjaxResult RoleItem(int id)
        {
            if (id == 0)
                return AjaxResult.Failed("错误,未获取正确的参数");
            if (_role.DeleteRole(id))
                return AjaxResult.Success("删除角色成功");
            return AjaxResult.Failed();
        }
        //角色权限 RoleAccess GP
        [HttpGet]
        public JsonResult RoleAccess(int roleid)
        {
            return Json(_role.GetRoleAccess(roleid));
        }
        [HttpPut]
        public AjaxResult RoleAccess(int roleid,string access)
        {
            if (string.IsNullOrEmpty(access) || roleid == 0)
                return AjaxResult.Failed("参数错误");
            if (_role.SetRoleAccess(roleid, access))
                return AjaxResult.Success();
            return AjaxResult.Failed();
        }
        ///SysUser用户管理 页面
        public IActionResult SysUser()
        {
            return View();
        }
        //用户列表api
        [HttpGet]
        public JsonResult UserList()
        {
            return Json(_user.GetUserList());
        }
        //用户项目api
        [HttpGet]
        public JsonResult UserItem(string id)
        {
            return Json(_user.FindByID(id));
        }
        //用户角色api
        [HttpGet]
        public JsonResult UserRoles(string uid)
        {
            return Json(_role.GetUserRolesByUserID(uid));
        }
        [HttpPut]
        public AjaxResult UserRoles(string uid,int roleid)
        {
            if (string.IsNullOrEmpty(uid) || roleid == 0)
                return AjaxResult.Failed("参数错误");
            if (_role.UserEditRole(uid, roleid))
                return AjaxResult.Success("操作成功");
            return AjaxResult.Failed();
        }

    }
}
