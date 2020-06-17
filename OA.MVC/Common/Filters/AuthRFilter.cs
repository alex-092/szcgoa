using CommonLib.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OA.Services.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.MVC.Common.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthRFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var claim = context.HttpContext.User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Sid);
            if(claim != null)
            {
                var _menu = EnginContext.Current.Resolve<IMenuService>();
                string _controller = TryGetRouteValue(context.HttpContext, "controller");
                string _action = TryGetRouteValue(context.HttpContext, "action");
                var uid = claim.Value;
                if (!_menu.CheckPath(_controller,_action, uid))
                {
                    context.Result = new RedirectToRouteResult("UnAuthrPage", new { returnUrl = context.HttpContext.Request.Path });
                }
            }
        }
        private string TryGetRouteValue(HttpContext context ,string type)
        {
            object result;
            if (context.Request.RouteValues.TryGetValue(type, out result))
            {
                return result.ToString();
            }
            return "";
        }
    }
}
