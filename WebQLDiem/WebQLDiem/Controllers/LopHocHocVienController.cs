using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;
using WebQLDiem.Enums;
using WebQLDiem.Models;
using WebQLDiem.Models.Meta;

namespace WebQLDiem.Controllers
{
    [HocVienAuthorize]
    public class LopHocHocVienController : BaseController
    {
        // GET: LopHoc
        public ActionResult Index()
        {
            var list = Db.HocViens.FirstOrDefault(x => x.MaTaiKhoan == MaTaiKhoan).LopHocs.Where(x => x.TrangThai == (int)TrangThaiLop.KichHoat).ToList();
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            try
            {
                var model = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == id && x.TrangThai == (int)TrangThaiLop.KichHoat && x.HocViens.Any(y => y.MaTaiKhoan == MaTaiKhoan));
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewTaiLieu(int id)
        {
            try
            {
                var model = Db.TaiLieux.FirstOrDefault(x => x.MaTaiLieu == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewTaiLieuNhanXet(int id)
        {
            try
            {
                var model = Db.TaiLieux.FirstOrDefault(x => x.MaTaiLieu == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewBaiTap(int id)
        {
            try
            {
                var model = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewThongBao(int id)
        {
            try
            {
                var model = Db.ThongBaos.FirstOrDefault(x => x.MaThongBao == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewThongBaoNhanXet(int id)
        {
            try
            {
                var model = Db.ThongBaos.FirstOrDefault(x => x.MaThongBao == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult ViewBaiTapNhanXet(int id)
        {
            try
            {
                var model = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult MoiNguoi(int id)
        {
            var model = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == id);
            return View("_MoiNguoi", model);
        }

        public ActionResult BaiTap(int id)
        {
            var model = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == id);
            return View("_BaiTap", model);
        }

        [HttpPost]
        public ActionResult TraoDoi(AddTraoDoiMeta model)
        {
            try
            {
                var bthv = new BaiTap_NhanXet
                {
                    MaBaiTap = model.MaBaiTap,
                    NguoiTao = MaTaiKhoan,
                    NgayTao = DateTime.Now,
                    NoiDung = model.NoiDung
                };

                Db.BaiTap_NhanXet.Add(bthv);
                Db.SaveChanges();

                var bt = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == model.MaBaiTap);

                SendThongBaoTaiKhoan(bt.NguoiTao, "Có 1 trao đổi mới tại bài tập [" + bt.TenBaiTap + "]", "Có 1 trao đổi mới tại bài tập [" + bt.TenBaiTap + "]");

                return Json(messeger.AddSuccess("Thêm thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Thêm không thành công"));
            }
        }

        [HttpPost]
        public ActionResult TraoDoiTaiLieu(AddTraoDoiTaiLieuMeta model)
        {
            try
            {
                var bthv = new TaiLieu_NhanXet
                {
                    MaTaiLieu = model.MaTaiLieu,
                    NguoiTao = MaTaiKhoan,
                    NgayTao = DateTime.Now,
                    NoiDung = model.NoiDung
                };

                Db.TaiLieu_NhanXet.Add(bthv);
                Db.SaveChanges();

                var bt = Db.TaiLieux.FirstOrDefault(x => x.MaTaiLieu == model.MaTaiLieu);

                SendThongBaoTaiKhoan(bt.NguoiTao, "Có 1 trao đổi mới tại tài liệu [" + bt.TenTaiLieu + "]", "Có 1 trao đổi mới tại tài liệu [" + bt.TenTaiLieu + "]");

                return Json(messeger.AddSuccess("Thêm thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Thêm không thành công"));
            }
        }

        [HttpPost]
        public ActionResult TraoDoiThongBao(AddTraoDoiThongBaoMeta model)
        {
            try
            {
                var bthv = new ThongBao_NhanXet
                {
                    MaThongBao = model.MaThongBao,
                    NguoiTao = MaTaiKhoan,
                    NgayTao = DateTime.Now,
                    NoiDung = model.NoiDung
                };

                Db.ThongBao_NhanXet.Add(bthv);
                Db.SaveChanges();

                var bt = Db.ThongBaos.FirstOrDefault(x => x.MaThongBao == model.MaThongBao);

                SendThongBaoTaiKhoan(bt.NguoiTao.Value, "Có 1 trao đổi mới tại thông báo trong lớp học [" + bt.LopHoc.TenLopHoc + "]", "Có 1 trao đổi mới tại thông báo trong lớp học [" + bt.LopHoc.TenLopHoc + "]");

                return Json(messeger.AddSuccess("Thêm thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Thêm không thành công"));
            }
        }

        public ActionResult ThongTinLopHoc(int malop)
        {
            var listThongTin = new List<ThongTinLopHop>();
            var lophoc = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == malop);
            if (lophoc != null)
            {
                foreach (var item in lophoc.BaiTaps.Where(x => x.TrangThai == (int)TrangThaiBaiTap.GiaoBaiTap && x.BaiTap_HocVien.Any(y => y.HocVien.MaTaiKhoan == MaTaiKhoan)).ToList())
                {
                    listThongTin.Add(new ThongTinLopHop
                    {
                        Id = item.MaBaiTap,
                        Title = $"{item.TaiKhoan.TenDangNhap} đã đăng 1 bài tập mới: {item.TenBaiTap}",
                        CreateDate = item.NgayTao.Value,
                        Type = (int)LoaiThongBao.BaiTap,
                        NguoiTao = item.NguoiTao
                    });
                }

                foreach (var item in lophoc.TaiLieux.Where(x => x.TrangThai >= (int)TrangThaiTaiLieu.GiaoTaiLieu && x.HocViens.Any(y => y.MaTaiKhoan == MaTaiKhoan)).ToList())
                {
                    listThongTin.Add(new ThongTinLopHop
                    {
                        Id = item.MaTaiLieu,
                        Title = $"{item.TaiKhoan.TenDangNhap} đã đăng 1 tài liệu mới: {item.TenTaiLieu}",
                        CreateDate = item.NgayTao,
                        Type = (int)LoaiThongBao.TaiLieu,
                        NguoiTao = item.NguoiTao
                    });
                }

                foreach (var item in lophoc.ThongBaos)
                {
                    listThongTin.Add(new ThongTinLopHop
                    {
                        Id = item.MaThongBao,
                        Title = $"{item.TaiKhoan.TenDangNhap} đã đăng 1 thông báo",
                        CreateDate = item.NgayTao.Value,
                        Type = (int)LoaiThongBao.ThongBao,
                        NguoiTao = item.NguoiTao.Value
                    });
                }
            }

            return View(listThongTin.OrderByDescending(x => x.CreateDate).ToList());
        }

        public ActionResult LoadNhanXet(TraoDoiView model)
        {
            var obj = new TraoDoiModel
            {
                Ma = model.Ma,
                Type = model.Type
            };

            if (model.Type == (int)LoaiThongBao.BaiTap)
            {
                var ot = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == model.Ma);
                if (ot != null)
                {
                    obj.Count = ot.BaiTap_NhanXet.Count();
                }
            }

            if (model.Type == (int)LoaiThongBao.TaiLieu)
            {
                var ot = Db.TaiLieux.FirstOrDefault(x => x.MaTaiLieu == model.Ma);
                if (ot != null)
                {
                    obj.Count = ot.TaiLieu_NhanXet.Count();
                }
            }

            if (model.Type == (int)LoaiThongBao.ThongBao)
            {
                var ot = Db.ThongBaos.FirstOrDefault(x => x.MaThongBao == model.Ma);
                if (ot != null)
                {
                    obj.Count = ot.ThongBao_NhanXet.Count();
                }
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LuuBaiTap(int id, string MoreImagesHV, string NoiDungGuiBai)
        {
            try
            {
                var obj = Db.BaiTap_HocVien.FirstOrDefault(x => x.MaBaiTap == id && x.HocVien.MaTaiKhoan == MaTaiKhoan);

                obj.TepDinhKem = MoreImagesHV;
                obj.NoiDungGuiBai = NoiDungGuiBai;

                Db.BaiTap_HocVien.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                return Json(messeger.AddSuccess("Lưu thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Lưu không thành công"));
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GiaoBaiTap(int id, string MoreImagesHV, string NoiDungGuiBai)
        {
            try
            {
                var obj = Db.BaiTap_HocVien.FirstOrDefault(x => x.MaBaiTap == id && x.HocVien.MaTaiKhoan == MaTaiKhoan);

                obj.TepDinhKem = MoreImagesHV;
                obj.NoiDungGuiBai = NoiDungGuiBai;
                obj.TrangThai = (int)TrangThaiBaiTap.NopBaiTap;
                obj.NgayNop = DateTime.Now;

                Db.BaiTap_HocVien.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                var bt = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == id);
                if (bt.TrangThai == (int)TrangThaiBaiTap.GiaoBaiTap)
                {
                    bt.TrangThai = (int)TrangThaiBaiTap.NopBaiTap;
                    Db.BaiTaps.Attach(bt);
                    Db.Entry(obj).State = EntityState.Modified;
                    Db.SaveChanges();
                }

                SendThongBaoTaiKhoan(bt.NguoiTao, "Học viên ["+ obj.HocVien.TenHocVien + "] nộp bài tập [" + bt.TenBaiTap + "]", "Học viên [" + obj.HocVien.TenHocVien + "] nộp bài tập [" + bt.TenBaiTap + "]");


                return Json(messeger.AddSuccess("Nộp thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Nộp không thành công"));
            }
        }
    }
}