using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebQLDiem.Enums;
using WebQLDiem.Helpper;
using WebQLDiem.Models;

namespace WebQLDiem.Controllers
{
    public class BaseController : Controller
    {
        protected static WebQLDiemEntities Db;
        public static int MaTaiKhoan;
        public static int adminType = (int)UserType.Admin;
        public static ShowMesseger messeger = new ShowMesseger();

        public BaseController()
        {
            Db = new WebQLDiemEntities();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            HttpCookie id = Request.Cookies.Get("Id");
            if (id == null)
            {
                MaTaiKhoan = 0;
            }
            else
            {
                MaTaiKhoan = int.Parse(id.Value);
            }
        }

        public void SendMailGiaoVien(int mataikhoan, string noidung)
        {
            try
            {
                var gv = Db.GiangViens.FirstOrDefault(x => x.MaTaiKhoan == mataikhoan);
                var domain = ConfigurationManager.AppSettings["Domain"];
                MailHelper.SendMail(gv.Email, "Hệ thống QL Điểm: " + domain, noidung, false);

            }
            catch (Exception)
            {

            }
        }

        public void SendMailHocVien(int mataikhoan, string noidung)
        {
            try
            {
                var hv = Db.HocViens.FirstOrDefault(x => x.MaTaiKhoan == mataikhoan);
                var domain = ConfigurationManager.AppSettings["Domain"];
                MailHelper.SendMail(hv.Email, "Hệ thống QL Điểm: " + domain, noidung, false);
            }
            catch (Exception)
            {
            }
        }

        public void SendThongBaoTaiKhoan(int mataikhoan, string tieude, string noidung)
        {
            var thongbao = new TaiKhoan_ThongBao
            {
                MaTaiKhoan = mataikhoan,
                TieuDe = tieude,
                NoiDung = noidung,
                NgayTao = DateTime.Now
            };

            Db.TaiKhoan_ThongBao.Add(thongbao);
            Db.SaveChanges();
        }
    }
}