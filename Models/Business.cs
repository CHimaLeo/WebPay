using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPay.Models
{
    public class Business
    {
        public string id_company { get; set; }
        public string id_branch { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }

        public Business(string id_company, string id_branch, string user, string pwd)
        {
            this.id_company = id_company;
            this.id_branch = id_branch;
            this.user = user;
            this.pwd = pwd;
        }
    }
}