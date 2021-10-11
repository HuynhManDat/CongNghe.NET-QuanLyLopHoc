using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;
using WebQLDiem.Enums;

namespace WebQLDiem.Controllers
{
    [HocVienAuthorize]
    public class DiemHocVienController : BaseController
    {
        // GET: Diem
        public ActionResult Index()
        {
            var hv = Db.HocViens.FirstOrDefault(x => x.MaTaiKhoan == MaTaiKhoan);
            var list = Db.BaiTap_HocVien.Where(x => x.TrangThai >= (int)TrangThaiBaiTap.NopBaiTap && x.HocVien.MaHocVien == hv.MaHocVien).ToList();
            return View(list);
        }
    }
}