using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models.Meta
{
    public class AddGiaoVienMeta
    {
        public int MaLopHoc { get; set; }
        public int MaGiaoVien { get; set; }
    }

    public class AddHocVienMeta
    {
        public int MaLopHoc { get; set; }
        public int MaHocVien { get; set; }
    }

    public class AddChuDeMeta
    {
        public int MaLopHoc { get; set; }
        public string TenChuDe { get; set; }
    }

    public class XoaChuDeMeta
    {
        public int MaLopHoc { get; set; }
        public int MaChuDe { get; set; }
    }

    public class AddTaiLieuMeta
    {
        public int MaLopHoc { get; set; }
        public int MaTaiLieu { get; set; }
    }

    public class AddBaiTapMeta
    {
        public int MaLopHoc { get; set; }
        public int MaBaiTap { get; set; }
    }

    public class AddTraoDoiMeta
    {
        public int MaBaiTap { get; set; }
        public string NoiDung { get; set; }
    }

    public class AddTraoDoiTaiLieuMeta
    {
        public int MaTaiLieu { get; set; }
        public string NoiDung { get; set; }
    }

    public class AddTraoDoiThongBaoMeta
    {
        public int MaThongBao { get; set; }
        public string NoiDung { get; set; }
    }
}