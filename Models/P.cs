using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPay.Models
{
    public class P
    {
        public Business business { get; set; }
        public Url url { get; set; }

        public P()
        {

        }

        public P(Business business, Url url)
        {
            this.business = business;
            this.url = url;
        }
    }
}