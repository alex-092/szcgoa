using CommonLib.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using OA.Services.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.MVC.Common.Services
{
    public class LayoutService
    {
        private IMenuService _menu; 
        private HttpContext _context;
        //props
        public string BC_UserSubID { get { return TryGetCliamValue(ClaimTypes.Sid); } }
        public string BC_UserDisplayName { get { return TryGetCliamValue(ClaimTypes.GivenName); } }
        public string BC_UserAccount { get { return TryGetCliamValue(ClaimTypes.Name); } }
        public string BC_ActivePath { get { return _context.Request.Path.ToString(); } }
        public string BC_ActiveController { get { return TryGetRouteValue("controller"); } }
        public string BC_ActiveAction { get { return TryGetRouteValue("action"); } }
        public string BC_ClientIP { get { return _context.Connection.RemoteIpAddress.ToString(); } }
        public enum HtmlType { Sidebar, Bread };

        public LayoutService(HttpContext context)
        {
            _menu = EnginContext.Current.Resolve<IMenuService>();
            _context = context;
        }
        private string TryGetCliamValue(string type)
        {
            var list = _context.User.Claims.ToList();
            foreach (var item in list)
            {
                if (item.Type == type)
                {
                    return item.Value;
                }
            }
            return "NotFound";
        }
        private string TryGetRouteValue(string type)
        {
            object result;
            if (_context.Request.RouteValues.TryGetValue(type, out result))
            {
                return result.ToString();
            }
            return "";
        }
        /// <summary>
        /// 根据登录的用户信息生成动态HTML.包括侧边栏与面包屑
        /// </summary>
        /// <param name="context">当前页面的httpcontenxt</param>
        /// <param name="type">生成的HTML类型,类型使用枚举HtmlType</param>
        /// <returns></returns>
        public HtmlString RenderSideBar(HtmlType type)
        {
            var titlelist = _menu.GetTitle(BC_UserSubID);
            string sidebar = "";
            string bread = "";
            if (titlelist != null)
            {
                foreach (var title in titlelist)
                {
                    if (title.Controller == BC_ActiveController)
                    {
                        sidebar += @"<li class='nav-item has-treeview  menu-open'><a href='javascript:void(0)' class='nav-link active'>" + title.Icon 
                            + @"<p>" + title.Title + @"<i class='right fa fa-angle-left'></i></p></a><ul class='nav nav-treeview'>";
                        bread += @"<li class='breadcrumb-item'><a href='/'>主页</a></li><li class='breadcrumb-item '>" + title.Title 
                            + @"</li><li class='breadcrumb-item active'>";
                    }
                    else
                    {
                        sidebar += @"<li class='nav-item has-treeview'><a href='javascript:void(0)' class='nav-link'>" + title.Icon 
                            + @"<p>" + title.Title + @"<i class='fa fa-angle-left right'></i></p></a><ul class='nav nav-treeview'>";
                    }
                    var menulist = _menu.GetSubMenu(title.Id, BC_UserSubID);
                    foreach (var item in menulist)
                    {
                        if (item.Action == BC_ActiveAction && item.Controller == BC_ActiveController)
                        {
                            sidebar += @"<li class='nav-item'><a href='/" + item.Controller + "/" + item.Action 
                                + @"'  class='nav-link active'>&nbsp;&nbsp;&nbsp;<i class='fa fa-angle-double-right' aria-hidden='true'></i>" + item.Icon + @"<p>" + item.Title + @"</p></a></li>";
                            bread += item.Title + @"</li>";
                        }
                        else
                        {
                            sidebar += @"<li class='nav-item'><a href='/" + item.Controller + "/" + item.Action 
                                + @"'  class='nav-link'><i class='fa fa-angle-double-right' aria-hidden='true'></i>" + item.Icon + @"<p>" + item.Title + @"</p></a></li>";
                        }
                    }
                    sidebar += @"</ul></li>";
                }
                if (type == HtmlType.Sidebar)
                {
                    return new HtmlString(sidebar);
                }
                else if (type == HtmlType.Bread)
                {
                    return new HtmlString(bread);
                }
            }
            return new HtmlString(@"<h3>no authorization</h3>");
        }
    }
}
