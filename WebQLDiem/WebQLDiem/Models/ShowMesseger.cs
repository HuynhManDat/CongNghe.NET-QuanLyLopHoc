using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models
{
    public class ShowMesseger
    {
        public bool IsError { get; set; }
        public string Messger { get; set; }

        public ShowMesseger()
        {
            IsError = false;
        }

        public ShowMesseger AddError(string mes)
        {
            this.IsError = true;
            this.Messger = mes;
            return this;
        }

        public ShowMesseger AddSuccess(string mes)
        {
            this.IsError = false;
            this.Messger = mes;
            return this;
        }
    }
}