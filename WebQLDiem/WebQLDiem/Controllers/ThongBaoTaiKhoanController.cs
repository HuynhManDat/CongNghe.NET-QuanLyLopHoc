using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQLDiem.Controllers
{
    public class ThongBaoTaiKhoanController : BaseController
    {
        // GET: ThongBaoTaiKhoan
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies.Get("UserFullName");
            if (cookie == null)
            {
                return Redirect("/login");
            }

            var lst = Db.TaiKhoan_ThongBao.OrderByDescending(x => x.NgayTao).ToList();
            return View(lst);
        }
    }
}