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
    public class DiemGiaoVienController : BaseController
    {
        // GET: Diem
        public ActionResult Index()
        {
            var list = Db.BaiTap_HocVien.Where(x => x.TrangThai >= (int)TrangThaiBaiTap.NopBaiTap && x.BaiTap.NguoiTao == MaTaiKhoan).ToList();
            return View(list);
        }

        public ActionResult Edit(int mabt, int mahv)
        {
            try
            {
                var model = Db.BaiTap_HocVien.FirstOrDefault(x => x.MaBaiTap == mabt && x.MaHocVien == mahv);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Edit(BaiTap_HocVien model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = Db.BaiTap_HocVien.FirstOrDefault(x => x.MaBaiTap == model.MaBaiTap && x.MaHocVien == model.MaHocVien);

                    obj.NgayChamDiem = DateTime.Now;
                    obj.DiemHocTap = model.DiemHocTap;
                    obj.DiemChuyenCan = model.DiemChuyenCan;
                    obj.NhanXetGiangVien = model.NhanXetGiangVien;
                    obj.TrangThai = (int)TrangThaiBaiTap.ChamDiem;

                    Db.BaiTap_HocVien.Attach(obj);
                    Db.Entry(obj).State = EntityState.Modified;
                    Db.SaveChanges();

                    var baitap = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == model.MaBaiTap);
                    baitap.TrangThai = (int)TrangThaiBaiTap.ChamDiem;
                    Db.BaiTaps.Attach(baitap);
                    Db.Entry(obj).State = EntityState.Modified;
                    Db.SaveChanges();

                    HttpCookie cookie = Request.Cookies["UserFullName"];

                    SendMailHocVien(obj.HocVien.MaTaiKhoan.Value, "Bài tập [" + obj.BaiTap.TenBaiTap + " - " + obj.BaiTap.LopHoc.TenLopHoc + "] của " + obj.HocVien.TenHocVien + " đã được chấm điểm bởi" + cookie.Value.ToString());
                    SendThongBaoTaiKhoan(obj.HocVien.MaTaiKhoan.Value, "Bài tập [" + obj.BaiTap.TenBaiTap + " - " + obj.BaiTap.LopHoc.TenLopHoc + "] của " + obj.HocVien.TenHocVien + " đã được chấm điểm", "Bài tập [" + obj.BaiTap.TenBaiTap + " - " + obj.BaiTap.LopHoc.TenLopHoc + "] của " + obj.HocVien.TenHocVien + " đã được chấm điểm bởi" + cookie.Value.ToString());
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
    }
}