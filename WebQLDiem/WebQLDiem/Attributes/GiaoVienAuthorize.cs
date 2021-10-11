using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebQLDiem.Enums;

namespace WebQLDiem.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GiaoVienAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get("UserFullName");

            if (cookie == null)
            {
                string returnUrl = null;
                if (filterContext.HttpContext.Request.HttpMethod.Equals("GET", System.StringComparison.CurrentCultureIgnoreCase))
                    returnUrl = filterContext.HttpContext.Request.RawUrl;

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", Action = "Index", ReturnUrl = returnUrl }));
            }
            else
            {
                HttpCookie cookieType = filterContext.HttpContext.Request.Cookies.Get("UserType");
                if (cookieType == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "PermissionDenied" }));
                }
                else
                {
                    if (int.Parse(cookieType.Value) != (int)UserType.GiaoVien)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "PermissionDenied" }));
                    }
                }
            }
        }
    }
}