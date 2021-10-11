using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Models;
using WebQLDiem.Models.Meta;

namespace WebQLDiem.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Profile()
        {
            HttpCookie id = Request.Cookies.Get("Id");
            if (id == null)
            {
                return Redirect("/login");
            }

            var userId = int.Parse(id.Value);

            var user = Db.TaiKhoans.FirstOrDefault(x => x.MaTaKhoan == userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult Profile(TaiKhoan model)
        {
            HttpCookie id = Request.Cookies.Get("Id");
            var userId = int.Parse(id.Value);

            if (ModelState.IsValid)
            {
                try
                {
                    var user = Db.TaiKhoans.FirstOrDefault(x => x.MaTaKhoan == userId);
                    user.HinhDaiDien = model.HinhDaiDien;

                    Db.TaiKhoans.Attach(user);
                    Db.Entry(user).State = EntityState.Modified;
                    Db.SaveChanges();

                    TempData["mess"] = "Sửa dữ liệu thành công";
                }
                catch
                {
                    TempData["mess"] = "Không thể sửa dữ liệu";
                }

                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ChangePassword()
        {
            HttpCookie id = Request.Cookies.Get("Id");
            if (id == null)
            {
                return Redirect("/login");
            }

            return View(new UserMeta());
        }

        [HttpPost]
        public ActionResult ChangePassword(UserMeta model)
        {
            HttpCookie id = Request.Cookies.Get("Id");
            var userId = int.Parse(id.Value);

            if (ModelState.IsValid)
            {
                try
                {
                    var user = Db.TaiKhoans.FirstOrDefault(x => x.MaTaKhoan == userId);
                    user.MatKhau = model.Password;

                    Db.TaiKhoans.Attach(user);
                    Db.Entry(user).State = EntityState.Modified;
                    Db.SaveChanges();

                    TempData["mess"] = "Đổi mật khẩu thành công";
                }
                catch
                {
                    TempData["mess"] = "Không thể sửa dữ liệu";
                }

                return View(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}