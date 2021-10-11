using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLDiem.Attributes;

namespace WebQLDiem.Controllers
{
    [GiaoVienAuthorize]
    public class TrangThaiGiaoVienController : BaseController
    {
        // GET: TrangThai
        public ActionResult Index(int? MaLopHoc)
        {
            var lstLopHoc = Db.LopHocs.Where(x => x.NguoiTao == MaTaiKhoan || x.GiangViens.Any(y => y.MaTaiKhoan == MaTaiKhoan)).ToList();
            if (MaLopHoc > 0)
            {
                lstLopHoc = lstLopHoc.Where(x => x.MaLopHoc == MaLopHoc).ToList();
            }

            ViewBag.MaLop = MaLopHoc;
            return View(lstLopHoc);
        }
    }
}