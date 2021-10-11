using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models
{
    public class TraoDoiView
    {
        public int Ma { get; set; }
        public int Type { get; set; }
    }

    public class TraoDoiModel
    {
        public int Ma { get; set; }
        public int Type { get; set; }
        public int Count { get; set; }
    }
}