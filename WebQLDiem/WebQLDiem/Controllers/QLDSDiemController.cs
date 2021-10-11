using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;
using WebQLDiem.Enums;
using WebQLDiem.Models;

namespace WebQLDiem.Controllers
{
    [AdminAuthorize]
    public class QLDSDiemController : BaseController
    {
        // GET: QLDiem
        public ActionResult Index(int? MaLopHoc, string TuNgay, string DenNgay, int? MaHocVien, int? TrangThai)
        {
            var lstHocVien = Db.HocViens.ToList();
            if (MaHocVien > 0)
            {
                lstHocVien = lstHocVien.Where(x => x.MaHocVien == MaHocVien).ToList();
            }
            var lstLopHoc = Db.LopHocs.ToList();

            if (MaLopHoc > 0)
            {
                lstLopHoc = lstLopHoc.Where(x => x.MaLopHoc == MaLopHoc).ToList();
            }

            var listBaiTap = Db.BaiTaps.ToList();

            var date = DateTime.Now;
            if (DateTime.TryParse(TuNgay, out date))
            {
                listBaiTap = listBaiTap.Where(x => x.NgayBatDau >= date).ToList();
            }
            if (DateTime.TryParse(DenNgay, out date))
            {
                listBaiTap = listBaiTap.Where(x => x.NgayKetThuc <= date).ToList();
            }

            if (TrangThai == (int)TrangThaiBaiTap.ChamDiem)
            {
                listBaiTap = listBaiTap.Where(x => x.TrangThai == TrangThai).ToList();
            }
            else if(TrangThai > 0)
            {
                listBaiTap = listBaiTap.Where(x => x.TrangThai <= TrangThai).ToList();
            }

            var listDB = new List<ViewBangDiem>();

            ViewBag.MaLop = MaLopHoc;
            ViewBag.MaHocVien = MaHocVien;
            ViewBag.TuNgay = TuNgay;
            ViewBag.DenNgay = DenNgay;

            foreach (var item in lstHocVien)
            {
                foreach (var lop in lstLopHoc.Where(x => x.HocViens.Any(y => y.MaHocVien == item.MaHocVien)))
                {
                    foreach (var bt in listBaiTap.Where(x => x.MaLopHoc == lop.MaLopHoc).ToList())
                    {
                        foreach (var diem in bt.BaiTap_HocVien.Where(x => x.MaHocVien == item.MaHocVien))
                        {
                            listDB.Add(new ViewBangDiem
                            {
                                Ten = item.TenHocVien,
                                Email = item.Email,
                                Lop = lop.TenLopHoc,
                                ChuDe = bt.ChuDe?.TenChuDe,
                                BaiTap = bt.TenBaiTap,
                                NgayGiao = bt.NgayBatDau,
                                NgayKetThuc = bt.NgayKetThuc,
                                DiemHocTap = diem.DiemHocTap ?? 0,
                                DiemChuyenCan = diem.DiemChuyenCan ?? 0,
                                ThangDiem = bt.ThangDiem,
                                ThangDiemChuyenCan = bt.ThangDiemChuyenCan
                            });
                        }
                    }
                }
            }

            return View(listDB);
        }
    }
}