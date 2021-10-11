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
    [AdminAuthorize]
    public class LopHocController : BaseController
    {
        // GET: LopHoc
        public ActionResult Index()
        {
            var list = Db.LopHocs.ToList();
            return View(list);
        }

        public ActionResult Add()
        {
            return View(new LopHoc() { NgayTao = DateTime.Now, NguoiTao = MaTaiKhoan });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LopHoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.NguoiTao = MaTaiKhoan;
                    model.NgayTao = DateTime.Now;
                    Db.LopHocs.Add(model);
                    Db.SaveChanges();

                    return RedirectToAction("detail", new { id = model.MaLopHoc });
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
                var model = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public ActionResult Edit(LopHoc model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                    obj.TenLopHoc = model.TenLopHoc;
                    obj.MoTa = model.MoTa;
                    obj.DiaChi = model.DiaChi;
                    obj.Phong = model.Phong;
                    obj.ChuDe = model.ChuDe;
                    obj.TrangThai = model.TrangThai;

                    Db.LopHocs.Attach(obj);
                    Db.Entry(obj).State = EntityState.Modified;
                    Db.SaveChanges();

                    return RedirectToAction("detail", new { id = model.MaLopHoc });
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
                var model = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == id);
                Db.LopHocs.Attach(model);
                Db.Entry(model).State = EntityState.Deleted;
                Db.LopHocs.Remove(model);
                Db.SaveChanges();
            }
            catch
            {
                TempData["mess"] = "Không thể xóa dữ liệu do có ràng buộc dữ liệu";
            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            try
            {
                var model = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult AddGiaoVien(int id)
        {
            return View(new AddGiaoVienMeta() { MaLopHoc = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddGiaoVien(AddGiaoVienMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.GiangViens.Count(x => x.MaGiangVien == model.MaGiaoVien) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có giáo viên này rồi"), JsonRequestBehavior.AllowGet);
                }

                var gv = Db.GiangViens.FirstOrDefault(x => x.MaGiangVien == model.MaGiaoVien);

                obj.GiangViens.Add(gv);

                Db.LopHocs.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                SendMailGiaoVien(gv.MaTaiKhoan.Value, "Bạn đã được thêm vào lớp [" + obj.TenLopHoc + "]");
                SendThongBaoTaiKhoan(gv.MaTaiKhoan.Value, "Bạn đã được thêm vào lớp [" + obj.TenLopHoc + "]", "Bạn đã được thêm vào lớp [" + obj.TenLopHoc + "]");

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(messeger.AddError("Thêm không thành công"), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult XoaGiaoVien(AddGiaoVienMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.GiangViens.Count(x => x.MaGiangVien == model.MaGiaoVien) == 0)
                {
                    return Json(messeger.AddError("Lớp chưa có giáo viên này"));
                }

                var gv = Db.GiangViens.FirstOrDefault(x => x.MaGiangVien == model.MaGiaoVien);

                obj.GiangViens.Remove(gv);

                Db.LopHocs.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                SendThongBaoTaiKhoan(gv.MaTaiKhoan.Value, "Bạn đã được xóa khỏi lớp [" + obj.TenLopHoc + "]", "Bạn đã được xóa khỏi lớp [" + obj.TenLopHoc + "]");

                return Json(messeger.AddSuccess("Xóa thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Xóa không thành công"));
            }
        }

        public ActionResult AddHocVien(int id)
        {
            return View(new AddHocVienMeta() { MaLopHoc = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddHocVien(AddHocVienMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.HocViens.Count(x => x.MaHocVien == model.MaHocVien) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có học viên này rồi"), JsonRequestBehavior.AllowGet);
                }

                var hv = Db.HocViens.FirstOrDefault(x => x.MaHocVien == model.MaHocVien);

                obj.HocViens.Add(hv);

                Db.LopHocs.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                SendMailHocVien(hv.MaTaiKhoan.Value, "Bạn đã được thêm vào lớp [" + obj.TenLopHoc + "]");


                SendThongBaoTaiKhoan(hv.MaTaiKhoan.Value, "Bạn đã được thêm vào lớp [" + obj.TenLopHoc + "]", "Bạn đã được thêm vào lớp [" + obj.TenLopHoc + "]");

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(messeger.AddError("Thêm không thành công"), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult XoaHocVien(AddHocVienMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.HocViens.Count(x => x.MaHocVien == model.MaHocVien) == 0)
                {
                    return Json(messeger.AddError("Lớp chưa có học viên này"));
                }

                var hv = Db.HocViens.FirstOrDefault(x => x.MaHocVien == model.MaHocVien);

                obj.HocViens.Remove(hv);

                Db.LopHocs.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                SendThongBaoTaiKhoan(hv.MaTaiKhoan.Value, "Bạn đã được xóa khỏi lớp [" + obj.TenLopHoc + "]", "Bạn đã được xóa khỏi lớp [" + obj.TenLopHoc + "]");

                return Json(messeger.AddSuccess("Xóa thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Xóa không thành công"));
            }
        }

        public ActionResult AddChuDe(int id)
        {
            return View(new AddChuDeMeta() { MaLopHoc = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddChuDe(AddChuDeMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.ChuDes.Count(x => x.TenChuDe == model.TenChuDe) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có chủ đề này rồi"), JsonRequestBehavior.AllowGet);
                }

                var chude = new ChuDe
                {
                    MaLopHoc = obj.MaLopHoc,
                    TenChuDe = model.TenChuDe,
                    NgayTao = DateTime.Now,
                    NguoiTao = MaTaiKhoan
                };

                Db.ChuDes.Add(chude);
                Db.SaveChanges();

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(messeger.AddError("Thêm không thành công"), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult XoaChuDe(XoaChuDeMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.ChuDes.Count(x => x.MaChuDe == model.MaChuDe) == 0)
                {
                    return Json(messeger.AddError("Lớp chưa có chủ đề này"));
                }

                var hv = Db.ChuDes.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc && x.MaChuDe == model.MaChuDe);

                obj.ChuDes.Remove(hv);

                Db.LopHocs.Attach(obj);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();

                return Json(messeger.AddSuccess("Xóa thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Xóa không thành công"));
            }
        }

        public ActionResult AddTaiLieu(int id)
        {
            return View(new TaiLieu() { MaLopHoc = id });
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult AddTaiLieu(TaiLieuMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.TaiLieux.Count(x => x.TenTaiLieu == model.TenTaiLieu) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có tài liệu này rồi"), JsonRequestBehavior.AllowGet);
                }

                var tl = new TaiLieu
                {
                    TenTaiLieu = model.TenTaiLieu,
                    MoTa = model.MoTa,
                    MaChuDe = model.MaChuDe,
                    MaLopHoc = model.MaLopHoc,
                    NgayTao = DateTime.Now,
                    NguoiTao = MaTaiKhoan,
                    TrangThai = (int)TrangThaiTaiLieu.TaoTaiLieu
                };

                Db.TaiLieux.Add(tl);
                Db.SaveChanges();

                if (!string.IsNullOrEmpty(model.MoreImages))
                {
                    var arr = model.MoreImages.Split(',');
                    foreach (var item in arr)
                    {
                        var tdk = new TaiLieuTepDinhKem()
                        {
                            DuongDan = item,
                            MaTaiLieu = tl.MaTaiLieu,
                            NgayTao = DateTime.Now,
                            NguoiTao = MaTaiKhoan
                        };

                        Db.TaiLieuTepDinhKems.Add(tdk);
                        Db.SaveChanges();
                    }
                }

                foreach (var item in model.HocViens)
                {
                    var mhv = int.Parse(item);
                    var hv = Db.HocViens.FirstOrDefault(x => x.MaHocVien == mhv);
                    if (hv != null)
                    {
                        hv.TaiLieux.Add(tl);

                        Db.HocViens.Attach(hv);
                        Db.Entry(obj).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                }

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(messeger.AddError("Thêm không thành công" + ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditTaiLieu(int id)
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

        [HttpPost]
        public ActionResult GiaoTaiLieu(int id)
        {
            try
            {
                var model = Db.TaiLieux.FirstOrDefault(x => x.MaTaiLieu == id);

                try
                {
                    model.TrangThai = (int)TrangThaiTaiLieu.GiaoTaiLieu;

                    Db.TaiLieux.Attach(model);
                    Db.Entry(model).State = EntityState.Modified;
                    Db.SaveChanges();

                    foreach (var hv in model.HocViens)
                    {
                        SendThongBaoTaiKhoan(hv.MaTaiKhoan.Value, "Bạn đã được gửi tài liệu tại lớp [" + model.LopHoc.TenLopHoc + "]", "Bạn đã được gửi tài liệu tại lớp [" + model.LopHoc.TenLopHoc + "]");
                    }
                }
                catch
                {
                    TempData["mess"] = "Không thể sửa dữ liệu";
                }

                return View("_BaiTap", Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc));
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditTaiLieu(TaiLieuMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.TaiLieux.Count(x => x.TenTaiLieu == model.TenTaiLieu && x.MaTaiLieu != model.MaTaiLieu) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có tài liệu này rồi"), JsonRequestBehavior.AllowGet);
                }

                var tl = Db.TaiLieux.FirstOrDefault(x => x.MaTaiLieu == model.MaTaiLieu);

                tl.TenTaiLieu = model.TenTaiLieu;
                tl.MoTa = model.MoTa;
                tl.MaChuDe = model.MaChuDe;

                Db.TaiLieux.Attach(tl);
                Db.Entry(tl).State = EntityState.Modified;
                Db.SaveChanges();


                var tepdks = Db.TaiLieuTepDinhKems.Where(x => x.MaTaiLieu == model.MaTaiLieu).ToList();
                foreach (var item in tepdks)
                {
                    Db.TaiLieuTepDinhKems.Attach(item);
                    Db.Entry(item).State = EntityState.Deleted;
                    Db.TaiLieuTepDinhKems.Remove(item);
                    Db.SaveChanges();
                }

                if (!string.IsNullOrEmpty(model.MoreImages))
                {
                    var arr = model.MoreImages.Split(',');
                    foreach (var item in arr)
                    {
                        var tdk = new TaiLieuTepDinhKem()
                        {
                            DuongDan = item,
                            MaTaiLieu = tl.MaTaiLieu,
                            NgayTao = DateTime.Now,
                            NguoiTao = MaTaiKhoan
                        };

                        Db.TaiLieuTepDinhKems.Add(tdk);
                        Db.SaveChanges();
                    }
                }

                var bthvs = tl.HocViens.ToList();
                foreach (var item in bthvs)
                {
                    tl.HocViens.Remove(item);

                    Db.TaiLieux.Attach(tl);
                    Db.Entry(tl).State = EntityState.Modified;
                    Db.SaveChanges();
                }

                foreach (var item in model.HocViens)
                {
                    var mhv = int.Parse(item);
                    var hv = Db.HocViens.FirstOrDefault(x => x.MaHocVien == mhv);
                    if (hv != null)
                    {
                        hv.TaiLieux.Add(tl);

                        Db.HocViens.Attach(hv);
                        Db.Entry(obj).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                }

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(messeger.AddError("Thêm không thành công" + ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult XoaTaiLieu(AddTaiLieuMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.TaiLieux.Count(x => x.MaTaiLieu == model.MaTaiLieu) == 0)
                {
                    return Json(messeger.AddError("Lớp chưa có tài liệu này"));
                }

                var hv = Db.TaiLieux.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc && x.MaTaiLieu == model.MaTaiLieu);


                Db.TaiLieux.Attach(hv);
                Db.Entry(model).State = EntityState.Deleted;
                Db.TaiLieux.Remove(hv);
                Db.SaveChanges();

                return Json(messeger.AddSuccess("Xóa thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Xóa không thành công"));
            }
        }

        public ActionResult AddThongBao(int id)
        {
            return View(new ThongBao() { MaLopHoc = id });
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult AddThongBao(ThongBaoMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.ThongBaos.Count(x => x.NoiDung == model.NoiDung) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có thông báo này rồi"), JsonRequestBehavior.AllowGet);
                }

                var tl = new ThongBao
                {
                    NoiDung = model.NoiDung,
                    MaLopHoc = model.MaLopHoc,
                    NgayTao = DateTime.Now,
                    NguoiTao = MaTaiKhoan
                };

                Db.ThongBaos.Add(tl);
                Db.SaveChanges();

                if (!string.IsNullOrEmpty(model.MoreImages))
                {
                    var arr = model.MoreImages.Split(',');
                    foreach (var item in arr)
                    {
                        var tdk = new ThongBaoTepDinhKem()
                        {
                            DuongDan = item,
                            MaThongBao = tl.MaThongBao,
                            NgayTao = DateTime.Now,
                            NguoiTao = MaTaiKhoan
                        };

                        Db.ThongBaoTepDinhKems.Add(tdk);
                        Db.SaveChanges();
                    }
                }

                foreach (var item in model.HocViens)
                {
                    var mhv = int.Parse(item);
                    var hv = Db.HocViens.FirstOrDefault(x => x.MaHocVien == mhv);
                    if (hv != null)
                    {
                        hv.ThongBaos.Add(tl);

                        Db.HocViens.Attach(hv);
                        Db.Entry(obj).State = EntityState.Modified;
                        Db.SaveChanges();

                        SendThongBaoTaiKhoan(hv.MaTaiKhoan.Value, "Bạn đã được thông báo tại lớp [" + obj.TenLopHoc + "]", "Bạn đã được thông báo tại lớp [" + obj.TenLopHoc + "]");
                    }
                }

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(messeger.AddError("Thêm không thành công" + ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AddBaiTap(int id)
        {
            return View(new BaiTap() { MaLopHoc = id, NgayBatDau = DateTime.Now, NgayKetThuc = DateTime.Now });
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult AddBaiTap(BaiTapMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.BaiTaps.Count(x => x.TenBaiTap == model.TenBaiTap) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có bài tập này rồi"), JsonRequestBehavior.AllowGet);
                }

                var tl = new BaiTap
                {
                    TenBaiTap = model.TenBaiTap,
                    MoTa = model.MoTa,
                    MaChuDe = model.MaChuDe,
                    MaLopHoc = model.MaLopHoc,
                    NgayBatDau = model.NgayBatDau,
                    NgayKetThuc = model.NgayKetThuc,
                    NguoiTao = MaTaiKhoan,
                    ThangDiem = model.ThangDiem,
                    ThangDiemChuyenCan = model.ThangDiemChuyenCan,
                    TrangThai = (int)TrangThaiBaiTap.TaoBaiTap,
                    NgayTao = DateTime.Now
                };

                Db.BaiTaps.Add(tl);
                Db.SaveChanges();

                if (!string.IsNullOrEmpty(model.MoreImages))
                {
                    var arr = model.MoreImages.Split(',');
                    foreach (var item in arr)
                    {
                        var tdk = new BaiTapTepDinhKem()
                        {
                            DuongDan = item,
                            MaBaiTap = tl.MaBaiTap,
                            NgayTao = DateTime.Now,
                            NguoiTao = MaTaiKhoan
                        };

                        Db.BaiTapTepDinhKems.Add(tdk);
                        Db.SaveChanges();
                    }
                }

                foreach (var item in model.HocViens)
                {
                    var bthv = new BaiTap_HocVien
                    {
                        MaBaiTap = tl.MaBaiTap,
                        MaHocVien = int.Parse(item),
                        TrangThai = (int)TrangThaiBaiTap.TaoBaiTap,
                        NgayGiao = DateTime.Now
                    };

                    Db.BaiTap_HocVien.Add(bthv);
                    Db.SaveChanges();
                }

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(messeger.AddError("Thêm không thành công" + ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditBaiTap(int id)
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

        [HttpPost]
        public ActionResult GiaoBaiTap(int id)
        {
            try
            {
                var model = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == id);

                try
                {
                    model.TrangThai = (int)TrangThaiBaiTap.GiaoBaiTap;

                    Db.BaiTaps.Attach(model);
                    Db.Entry(model).State = EntityState.Modified;
                    Db.SaveChanges();

                    var list = Db.BaiTap_HocVien.Where(x => x.MaBaiTap == model.MaBaiTap).ToList();
                    foreach (var item in list)
                    {
                        item.TrangThai = (int)TrangThaiBaiTap.GiaoBaiTap;

                        Db.BaiTap_HocVien.Attach(item);
                        Db.Entry(item).State = EntityState.Modified;
                        Db.SaveChanges();

                        SendMailHocVien(item.HocVien.MaTaiKhoan.Value, "Bạn đã được giao bài tập [" + item.BaiTap.TenBaiTap + "]");
                        SendThongBaoTaiKhoan(item.HocVien.MaTaiKhoan.Value, "Bạn đã được giao bài tập tại lớp [" + model.LopHoc.TenLopHoc + "]", "Bạn đã được giao bài tập tại lớp [" + model.LopHoc.TenLopHoc + "]");
                    }
                }
                catch
                {
                    TempData["mess"] = "Không thể sửa dữ liệu";
                }

                return View("_BaiTap", Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc));
            }
            catch
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditBaiTap(BaiTapMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.BaiTaps.Count(x => x.TenBaiTap == model.TenBaiTap && x.MaBaiTap != model.MaBaiTap) > 0)
                {
                    return Json(messeger.AddError("Lớp đã có bài tập này rồi"), JsonRequestBehavior.AllowGet);
                }

                var tl = Db.BaiTaps.FirstOrDefault(x => x.MaBaiTap == model.MaBaiTap);


                tl.TenBaiTap = model.TenBaiTap;
                tl.MoTa = model.MoTa;
                tl.MaChuDe = model.MaChuDe;
                tl.NgayBatDau = model.NgayBatDau;
                tl.NgayKetThuc = model.NgayKetThuc;
                tl.ThangDiem = model.ThangDiem;
                tl.ThangDiemChuyenCan = model.ThangDiemChuyenCan;

                Db.BaiTaps.Attach(tl);
                Db.Entry(tl).State = EntityState.Modified;
                Db.SaveChanges();


                var tepdks = Db.BaiTapTepDinhKems.Where(x => x.MaBaiTap == model.MaBaiTap).ToList();
                foreach (var item in tepdks)
                {
                    Db.BaiTapTepDinhKems.Attach(item);
                    Db.Entry(item).State = EntityState.Deleted;
                    Db.BaiTapTepDinhKems.Remove(item);
                    Db.SaveChanges();
                }

                if (!string.IsNullOrEmpty(model.MoreImages))
                {
                    var arr = model.MoreImages.Split(',');
                    foreach (var item in arr)
                    {
                        var tdk = new BaiTapTepDinhKem()
                        {
                            DuongDan = item,
                            MaBaiTap = tl.MaBaiTap,
                            NgayTao = DateTime.Now,
                            NguoiTao = MaTaiKhoan
                        };

                        Db.BaiTapTepDinhKems.Add(tdk);
                        Db.SaveChanges();
                    }
                }

                var bthvs = Db.BaiTap_HocVien.Where(x => x.MaBaiTap == model.MaBaiTap).ToList();
                foreach (var item in bthvs)
                {
                    Db.BaiTap_HocVien.Attach(item);
                    Db.Entry(item).State = EntityState.Deleted;
                    Db.BaiTap_HocVien.Remove(item);
                    Db.SaveChanges();
                }

                foreach (var item in model.HocViens)
                {
                    var bthv = new BaiTap_HocVien
                    {
                        MaBaiTap = tl.MaBaiTap,
                        MaHocVien = int.Parse(item),
                        TrangThai = (int)TrangThaiBaiTap.TaoBaiTap,
                        NgayGiao = DateTime.Now
                    };

                    Db.BaiTap_HocVien.Add(bthv);
                    Db.SaveChanges();
                }

                return Json(messeger.AddSuccess("Thêm thành công"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(messeger.AddError("Thêm không thành công" + ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult XoaBaiTap(AddBaiTapMeta model)
        {
            try
            {
                var obj = Db.LopHocs.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc);

                if (obj.BaiTaps.Count(x => x.MaBaiTap == model.MaBaiTap) == 0)
                {
                    return Json(messeger.AddError("Lớp chưa có bài tập này"));
                }

                var hv = Db.BaiTaps.FirstOrDefault(x => x.MaLopHoc == model.MaLopHoc && x.MaBaiTap == model.MaBaiTap);

                Db.BaiTaps.Attach(hv);
                Db.Entry(model).State = EntityState.Deleted;
                Db.BaiTaps.Remove(hv);
                Db.SaveChanges();

                return Json(messeger.AddSuccess("Xóa thành công"));
            }
            catch
            {
                return Json(messeger.AddError("Xóa không thành công"));
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

                foreach(var hv in bt.BaiTap_HocVien)
                {
                    SendThongBaoTaiKhoan(hv.HocVien.MaTaiKhoan.Value, "Có 1 trao đổi mới tại bài tập ["+bt.TenBaiTap+"]", "Có 1 trao đổi mới tại bài tập [" + bt.TenBaiTap + "]");
                }

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

                foreach (var hv in bt.HocViens)
                {
                    SendThongBaoTaiKhoan(hv.MaTaiKhoan.Value, "Có 1 trao đổi mới tại tài liệu [" + bt.TenTaiLieu + "]", "Có 1 trao đổi mới tại tài liệu [" + bt.TenTaiLieu + "]");
                }

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

                foreach (var hv in bt.HocViens)
                {
                    SendThongBaoTaiKhoan(hv.MaTaiKhoan.Value, "Có 1 trao đổi mới tại thông báo trong lớp học [" + bt.LopHoc.TenLopHoc + "]", "Có 1 trao đổi mới tại thông báo trong lớp học [" + bt.LopHoc.TenLopHoc + "]");
                }

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
                foreach (var item in lophoc.BaiTaps.Where(x => x.TrangThai >= (int)TrangThaiBaiTap.GiaoBaiTap).ToList())
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

                foreach (var item in lophoc.TaiLieux.Where(x => x.TrangThai >= (int)TrangThaiTaiLieu.GiaoTaiLieu).ToList())
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
    }
}