using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models.Meta
{
    public class ThongTinLopHop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int Type { get; set; }
        public int NguoiTao { get; set; }

    }

    public enum LoaiThongBao
    {
        BaiTap,
        TaiLieu,
        ThongBao
    }
}