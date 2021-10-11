using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;
using WebQLDiem.Enums;
using WebQLDiem.Models;

namespace WebQLDiem.Controllers
{
    [GiaoVienAuthorize]
    public class ChuDeGiaoVienController : BaseController
    {
        // GET: ChuDenGiaoVien
        public ActionResult Index()
        {
            var list = Db.ChuDes.Where(x => x.TaiKhoan.LoaiTaiKhoan == adminType || x.NguoiTao == MaTaiKhoan).ToList();
            return View(list);
        }

        public ActionResult Add()
        {
            return View(new ChuDe());
        }

        [HttpPost]
        public ActionResult Add(ChuDe model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Db.ChuDes.Any(x => x.TenChuDe == model.TenChuDe))
                    {
                        TempData["mess"] = "Chủ đề đã tồn tại";
                        return View(model);
                    }
                    else
                    {
                        model.NgayTao = DateTime.Now;
                        model.NguoiTao = MaTaiKhoan;
                        Db.ChuDes.Add(model);
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
                var model = Db.ChuDes.Where(x => x.NguoiTao == MaTaiKhoan).FirstOrDefault(x => x.MaChuDe == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ChuDe model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Db.ChuDes.Any(x => x.TenChuDe == model.TenChuDe && x.MaChuDe != model.MaChuDe))
                    {
                        TempData["mess"] = "Chủ đề đã tồn tại";
                        return View(model);
                    }
                    else
                    {
                        var obj = Db.ChuDes.Where(x => x.NguoiTao == MaTaiKhoan).FirstOrDefault(x => x.MaChuDe == model.MaChuDe);

                        //obj.TenDangNhap = model.TenDangNhap;
                        obj.TenChuDe = model.TenChuDe;

                        Db.ChuDes.Attach(obj);
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
                var model = Db.ChuDes.Where(x => x.NguoiTao == MaTaiKhoan).FirstOrDefault(x => x.MaChuDe == id);
                Db.ChuDes.Attach(model);
                Db.Entry(model).State = EntityState.Deleted;
                Db.ChuDes.Remove(model);
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