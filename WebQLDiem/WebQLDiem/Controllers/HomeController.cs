using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLDiem.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies.Get("UserFullName");
            if (cookie == null)
            {
                return Redirect("/login");
            }

            return View();
        }

        public ActionResult PermissionDenied()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies.Get("UserFullName");
            if (cookie == null)
            {
                return Redirect("/login");
            }

            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            HttpCookie id = Request.Cookies.Get("Id");
            id.Expires = DateTime.Now;
            Response.Cookies.Add(id);
            return Redirect("/login");
        }
    }
}