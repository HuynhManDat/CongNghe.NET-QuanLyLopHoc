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
    public class TrangThaiHocVienController : BaseController
    {
        // GET: TrangThaiHocVien
        public ActionResult Index(int? MaLopHoc)
        {
            var lstLopHoc = Db.HocViens.FirstOrDefault(x => x.MaTaiKhoan == MaTaiKhoan).LopHocs.Where(x => x.TrangThai == (int)TrangThaiLop.KichHoat).ToList();
            if (MaLopHoc > 0)
            {
                lstLopHoc = lstLopHoc.Where(x => x.MaLopHoc == MaLopHoc).ToList();
            }

            ViewBag.MaLop = MaLopHoc;
            return View(lstLopHoc);
        }
    }
}