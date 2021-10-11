using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;
using WebQLDiem.Models;

namespace WebQLDiem.Controllers
{
    [AdminAuthorize]
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            var list = Db.TaiKhoans.ToList();
            return View(list);
        }

        public ActionResult Add()
        {
            return View(new TaiKhoan());
        }

        [HttpPost]
        public ActionResult Add(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Db.TaiKhoans.Any(x => x.TenDangNhap == model.TenDangNhap))
                    {
                        TempData["mess"] = "Tài khoản đã tồn tại";
                        return View(model);
                    }
                    else
                    {
                        model.NgayTao = DateTime.Now;
                        Db.TaiKhoans.Add(model);
                        Db.SaveChanges();
                    }
                }
                catch
                {
                    TempData["mess"] = "Không thể thêm dữ liệu";
                }

                return RedirectToAction("index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var model = Db.TaiKhoans.FirstOrDefault(x => x.MaTaKhoan == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Edit(TaiKhoan model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Db.TaiKhoans.Any(x => x.TenDangNhap == model.TenDangNhap && x.MaTaKhoan != model.MaTaKhoan))
                    {
                        TempData["mess"] = "Tài khoản đã tồn tại";
                        return View(model);
                    }
                    else
                    {
                        var obj = Db.TaiKhoans.FirstOrDefault(x => x.MaTaKhoan == model.MaTaKhoan);

                        //obj.TenDangNhap = model.TenDangNhap;
                        obj.MatKhau = model.MatKhau;

                        Db.TaiKhoans.Attach(obj);
                        Db.Entry(obj).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                }
                catch
                {
                    TempData["mess"] = "Không thể sửa dữ liệu";
                }

                return RedirectToAction("index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var model = Db.TaiKhoans.FirstOrDefault(x => x.MaTaKhoan == id);
                Db.TaiKhoans.Attach(model);
                Db.Entry(model).State = EntityState.Deleted;
                Db.TaiKhoans.Remove(model);
                Db.SaveChanges();
            }
            catch
            {
                TempData["mess"] = "Không thể xóa dữ liệu do có ràng buộc dữ liệu";
            }
            return RedirectToAction("index");
        }
    }
}