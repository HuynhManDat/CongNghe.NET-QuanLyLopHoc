using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models
{
    public class DiemBaiTap
    {
        public string TenHocVien { get; set; }
        public List<LH> DSLopHoc { get; set; }
    }

    public class LH
    {
        public string TenLopHoc { get; set; }
        public List<BT> DSBaiTap { get; set; }
    }

    public class BT
    {
        public string TenBaiTap { get; set; }
        public int DiemHocTap { get; set; }
        public int DiemChuyenCan { get; set; }
        public int ThangDiem { get; set; }
        public int ThangDiemChuyenCan { get; set; }
    }

    public class ViewBangDiem {
        public string Ten { get; set;}
        public string Email { get; set; }
        public string Lop { get; set; }
        public string ChuDe { get; set; }
        public string BaiTap { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int DiemHocTap { get; set; }
        public int DiemChuyenCan { get; set; }
        public int ThangDiem { get; set; }
        public int ThangDiemChuyenCan { get; set; }
    }

}