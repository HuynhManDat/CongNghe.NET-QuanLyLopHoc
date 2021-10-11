using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;
using WebQLDiem.Models;

namespace WebQLDiem.Controllers
{
    [AdminAuthorize]
    public class QLDiemController : BaseController
    {
        // GET: QLDiem
        public ActionResult Index(int? MaLopHoc, string TuNgay, string DenNgay, int? MaHocVien)
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

            var listDB = new List<DiemBaiTap>();

            ViewBag.MaLop = MaLopHoc;
            ViewBag.MaHocVien = MaHocVien;
            ViewBag.TuNgay = TuNgay;
            ViewBag.DenNgay = DenNgay;

            foreach (var item in lstHocVien)
            {
                var lh = new List<LH>();
                foreach (var lop in lstLopHoc)
                {
                    if (lop.HocViens.Count(x => x.MaHocVien == item.MaHocVien) > 0)
                    {
                        var ld = new List<BT>();
                        foreach (var bt in listBaiTap.Where(x=>x.MaLopHoc == lop.MaLopHoc).ToList())
                        {
                            var b = bt.BaiTap_HocVien.FirstOrDefault(x => x.HocVien.MaHocVien == item.MaHocVien && bt.MaBaiTap == x.MaBaiTap);
                            if (b != null)
                            {
                                ld.Add(new BT
                                {
                                    TenBaiTap = bt.TenBaiTap,
                                    DiemChuyenCan = b.DiemChuyenCan == null ? 0 : b.DiemChuyenCan.Value,
                                    DiemHocTap = b.DiemHocTap == null ? 0 : b.DiemHocTap.Value,
                                    ThangDiem = b.BaiTap.ThangDiem,
                                    ThangDiemChuyenCan = b.BaiTap.ThangDiemChuyenCan                                    
                                });

                            }
                            else
                            {
                                ld.Add(new BT
                                {
                                    TenBaiTap = bt.TenBaiTap
                                });
                            }
                        }

                        lh.Add(new LH
                        {
                            TenLopHoc = lop.TenLopHoc,
                            DSBaiTap = ld
                        });
                    }
                    else
                    {
                        var ld = new List<BT>();
                        foreach (var bt in listBaiTap.Where(x => x.MaLopHoc == lop.MaLopHoc).ToList())
                        {
                            ld.Add(new BT
                            {
                                TenBaiTap = bt.TenBaiTap
                            });
                        }

                        lh.Add(new LH
                        {
                            TenLopHoc = lop.TenLopHoc,
                            DSBaiTap = ld
                        });
                    }
                }

                listDB.Add(new DiemBaiTap
                {
                    TenHocVien = item.TenHocVien,
                    DSLopHoc = lh
                });
            }


            return View(listDB);
        }
    }
}