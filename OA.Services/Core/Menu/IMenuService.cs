using Microsoft.Extensions.Caching.Memory;
using OA.Entitys.OaCoreDB;
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
    }

    public class MenuService : IMenuService
    {
        private readonly oa_coreContext _db;
        private readonly IMemoryCache _cache; //= new MemoryCache(new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        public MenuService(oa_coreContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
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
            var result = new List<SysMenu>();
            //if (!_cache.TryGetValue("Admin-Menu", out result))
            //{
            //    result = _db.SysMenu.OrderBy(o => o.Order).ToList();
            //    _cache.Set("Admin-Menu", result, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
            //}

            result = _db.SysMenu.OrderBy(o => o.Order).ToList();

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
    }
}
