using Microsoft.Extensions.Caching.Memory;
using OA.Entitys.OaAuthDB;
using OA.Entitys.OaCoreDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OA.Services.Core.Menu
{
    public interface IMenuService
    {
        /// <summary>
        /// 添加新菜单
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="level"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        bool AddMenu(int pid, string title, string icon, string controller, string action, int level, int order);
        /// <summary>
        /// 按id删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteMenu(int id);
        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="level"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        bool EditMenu(int id, int pid, string title, string icon, string controller, string action, int level, int order);
        /// <summary>
        /// 获取所有菜单项目
        /// </summary>
        /// <returns></returns>
        List<SysMenu> GetAllMenu();
        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<SysMenu> GetSubMenu(int pid, string userID = null);
        /// <summary>
        /// 获取控制器
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<SysMenu> GetTitle(string userID = null);
        /// <summary>
        /// 按用户权限查找用户授权的系统菜单
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<SysMenu> GetUserMenu(string userID);
        /// <summary>
        /// 判断用户是否有访问path的权限
        /// </summary>
        /// <param name="path"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool CheckPath(string controller, string action, string uid);
    }

    public class MenuService : IMenuService
    {
        private readonly oa_coreContext _db;
        private readonly oa_authContext _authDB;
        private readonly IMemoryCache _cache; //= new MemoryCache(new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        public MenuService(oa_coreContext db, IMemoryCache cache, oa_authContext authDB)
        {
            _db = db;
            _cache = cache;
            _authDB = authDB;
        }

        public bool AddMenu(int pid, string title, string icon, string controller, string action, int level, int order)
        {
            _db.SysMenu.Add(new SysMenu
            {
                Pid = pid,
                Title = title,
                Icon = icon,
                Controller = controller,
                Action = action,
                MenuLevel = (sbyte)level,
                Type = 0,
                Order = order
            });
            _db.SaveChanges();
            return true;
        }
        public bool EditMenu(int id, int pid, string title, string icon, string controller, string action, int level, int order)
        {
            var item = _db.SysMenu.Where(o => o.Id == id).FirstOrDefault();
            if (item == null)
                return false;
            item.Pid = pid;
            item.Title = title;
            item.Icon = icon;
            item.Controller = controller;
            item.Action = action;
            item.MenuLevel = (sbyte)level;
            item.Type = 0;
            item.Order = order;
            _db.SysMenu.Update(item);
            _db.SaveChanges();
            return true;
        }
        public bool DeleteMenu(int id)
        {
            var item = _db.SysMenu.Where(o => o.Id == id).FirstOrDefault();
            if (item == null)
                return false;
            _db.SysMenu.Remove(item);
            _db.SaveChanges();
            return true;
        }
        public List<SysMenu> GetAllMenu()
        {
            return _db.SysMenu.OrderBy(o => o.Order).ToList();
        }
        public List<SysMenu> GetUserMenu(string userID)
        {
            if (string.IsNullOrEmpty(userID))
                throw new ArgumentException("MenuService.GetUserMenu is error", nameof(userID));
            var allMenu = GetAllMenu();
            //取角色对应表
            var roles = _authDB.AuthUserRoles.Where(o => o.UserId == userID).ToList();
            //通过对应表取所有访问字符串并tolist
            var accessList = new List<List<string>>();
            foreach (var item in roles)
            {
                var tempItem = _db.AuthRoleAccess.FirstOrDefault(o => o.RoleId == item.RoleId);
                if(tempItem != null)
                    accessList.Add(tempItem.MenuIdString.Split(',').ToList());
            }
            //访问字符串集合去重
            var rawArray = new List<string>();
            foreach (var item in accessList)
            {
                rawArray = rawArray.Union(item).ToList();
            }
            //通过访问字符串列表查menu的id列表,由于前端ui树形组件不添加父组件id，后端判断添加
            var menuIDList = new List<int>();
            foreach (var item in rawArray)
            {
                var targetMenu = allMenu.FirstOrDefault(o => o.Id == int.Parse(item));
                if(targetMenu != null)
                {
                    menuIDList.Add(targetMenu.Id);
                    if (targetMenu.Pid != 0)
                    {
                        var targetMenuX = allMenu.FirstOrDefault(o => o.Id == targetMenu.Pid);
                        if (targetMenuX != null)
                        {
                            menuIDList.Add(targetMenuX.Id);
                            if (targetMenuX.Pid != 0)
                            {
                                var targetMenuY = allMenu.FirstOrDefault(o => o.Id == targetMenuX.Pid);
                                if (targetMenuY != null)
                                {
                                    menuIDList.Add(targetMenuY.Id);
                                }
                                
                            }
                        }
                        
                    }
                }
                   
            }
            menuIDList = menuIDList.Distinct().ToList();
            //最后用合法menuid取menulist
            List<SysMenu> result = new List<SysMenu>();
            foreach (var item in menuIDList)
            {
                result.Add(allMenu.FirstOrDefault(o => o.Id == item));
            }




            //if (!_cache.TryGetValue(userID, out result))
            //{
            //    result = _db.SysMenu.OrderBy(o => o.Order).ToList();
            //    _cache.Set(userID, result, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
            //}
            return result;
            
        }
        public List<SysMenu> GetTitle(string userID = null)
        {
            var rawList = GetUserMenu(userID);
            return rawList.Where(o => o.MenuLevel == 0).ToList();
        }
        public List<SysMenu> GetSubMenu(int pid, string userID = null)
        {
            var rawList = GetUserMenu(userID);
            return rawList.Where(o => o.Pid == pid).ToList();
        }
        public bool CheckPath(string controller,string action, string uid)
        {
            if ( string.IsNullOrEmpty(uid))
            {
                throw new ArgumentException("MenuService.checkPath is error", nameof(uid));
            }
            //超级管理员id
            if (uid == "c3324c8e-26dc-4d76-a84e-d4a676793c3d")
                return true;
            var legalMenu = GetUserMenu(uid);
            foreach (var item in legalMenu)
            {
                if (item.Controller.ToLower() == controller.ToLower())
                    if (item.Action.ToLower() == action.ToLower() || string.IsNullOrEmpty(item.Action))
                        return true;
            }
            return false;
        }
    }
}
