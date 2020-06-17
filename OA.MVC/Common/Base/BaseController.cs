using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.MVC.Common.Base
{
    public class BaseController : Controller
    {
        protected string BC_UserSubID { get { return TryGetCliamValue(ClaimTypes.Sid); } }
        protected string BC_UserDisplayName { get { return TryGetCliamValue(ClaimTypes.GivenName); } }
        protected string BC_UserAccount { get { return TryGetCliamValue(ClaimTypes.Name); } }
        protected string BC_ActivePath { get { return HttpContext.Request.Path.ToString(); } }
        protected string BC_ActiveController { get { return TryGetRouteValue("controller"); } }
        protected string BC_ActiveAction { get { return TryGetRouteValue("action"); } }
        protected string BC_ClientIP { get { return HttpContext.Connection.RemoteIpAddress.ToString(); } }
        protected bool BC_IsAjax { get { return HttpContext.Request.Headers.ContainsKey("x-requested-with"); } }

        //
        //private readonly IOaLogService _log;
        //public BaseController()
        //{
        //    _log = EnginContext.Current.Resolve<IOaLogService>();
        //}
        private string TryGetCliamValue(string type)
        {
            var list = User.Claims.ToList();
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
            if(HttpContext.Request.RouteValues.TryGetValue(type,out result))
            {
                return result.ToString();
            }
            return "";
        }
    }


    public class AjaxResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }

        public static AjaxResult Success()
        {
            return new AjaxResult() { Code = 200, Status = true, Message = "操作成功" };
        }
        public static AjaxResult Success(string message)
        {
            return new AjaxResult() { Code = 200, Status = true, Message = message };
        }
        public static AjaxResult Failed()
        {
            return new AjaxResult() { Code = 406, Status = false, Message = "内部错误" };
        }
        public static AjaxResult Failed(string message, int code = 406)
        {
            return new AjaxResult() { Code = code, Status = false, Message = message };
        }
    }
}
