using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE
{
    public class Payment: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; } //1st
        public string? OrderNo { get; set; }// 2nd
        public DateTime? DatePaid { get; set; }//3rd
        public string? PreparedBy { get; set; }
        public DateTime DatePrepared { get; set; }
        public bool? IsPaid { get; set; }
        public TimeSpan? TimePaid { get; set; }
        public string? ReceiptNo { get; set; }
        public string? CheckNo { get; set; }
        public string? Remark { get; set; }
        public string? CashierName { get; set; }
        public bool? Void { get; set; }
        public decimal TotalPayment { get; set; }//4th
        public bool? IsOtherPayment { get; set; }
        public string? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }

        public string? UpdatedBy { get; set; }
        public string? ReceiptNoHash { get; set; }
        public bool isPenalityLifted { get; set; }
        public string? BankReceiptNo { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public string? PaymentMethod { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime? MaximumDateBeforeRecaclulation { get; set; }
        public string? CasherUID { get; set; }
        public string? PaymentHash { get; set; }
        public string? Tin { get; set; }
        public string? BusinessNameAmh { get; set; }
        public string? FileNumber { get; set; }
        public string? Woreda { get; set; }
        public string? Kebele { get; set; }
        public string? HouseNo { get; set; }
        public string? TeleNo { get; set; } //5th
        public string? DerashStatus { get; set; }
    }
    public class BankReceipt
    {
        public string? bill_id { get; set; }
        public string? bill_desc { get; set; }
        public string? reason { get; set; }
        public double amount_due { get; set; }
        public string? due_date { get; set; }
        public bool partial_pay_allowed { get; set; }
        public string? customer_id { get; set; }
        public string? name { get; set; }
        public string? mobile { get; set; }
        public string? email { get; set; }

    }
}
