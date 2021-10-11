using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models.Meta
{
    public class TaiLieuMeta : TaiLieu
    {
        public string MoreImages { get; set; }
        public string[] HocViens { get; set; }
    }

    public class BaiTapMeta : BaiTap
    {
        public string MoreImages { get; set; }
        public string[] HocViens { get; set; }
    }

    public class ThongBaoMeta : ThongBao
    {
        public string MoreImages { get; set; }
        public string[] HocViens { get; set; }
    }
}