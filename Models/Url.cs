using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPay.Models
{
    public class Url
    {
        public string reference { get; set; }
        public double amount { get; set; }
        public string moneda { get; set; }
        public string canal { get; set; }
        public int omitir_notif_default { get; set; }
        public DateTime fh_vigencia { get; set; }

        public Url(string reference, double amount, string moneda, string canal, int omitir_notif_default, DateTime fh_vigencia)
        {
            this.reference = reference;
            this.amount = amount;
            this.moneda = moneda;
            this.canal = canal;
            this.omitir_notif_default = omitir_notif_default;
            this.fh_vigencia = fh_vigencia;
        }
    }
}