using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Entity
{
    public class PaymentViewModel
    {
        public string OrderNo { get; set; } = "Default Key";// 2nd
        public string Tin { get; set; }= "000000000";
        public string TeleNo { get; set; } = "000000000";//5th
        public string BusinessNameAmh { get; set; } = "No Company Name";
        public decimal TotalPayment { get; set; }//4th
        public string BankName { get; set; } = "No Bank";
        public string AccountNumber { get; set; } = "000000000000";
        public string? CenterName { get; set; }
        public DateTime DatePrepared { get; set; }

    }
}
