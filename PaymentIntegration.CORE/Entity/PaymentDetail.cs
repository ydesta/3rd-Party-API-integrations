using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE
{
    public class PaymentDetail:BaseEntity
    {
        public int Id { get; set; }
        public int AssessmentDetailId { get; set; }
        public int PaymentId { get; set; }
        public decimal RawTax { get; set; }
        public int TaxType { get; set; }
        public int FisicalYear { get; set; }
        public decimal LateFilingPenality { get; set; }
        public decimal LatePaymentPenalty { get; set; }
        public decimal InproperRecordingPenalty { get; set; }
        public decimal UnderStatementPenalty { get; set; }
        public decimal Interest { get; set; }
        public string? UpdatedUserName { get; set; }
        public string? PaymentHash { get; set; }
        public int month { get; set; }
        public int YeartTo { get; set; }
        public bool IsPaymentTaxAccountOpening { get; set; }
        public bool isDriverAssessment { get; set; }
        public bool IsVehicleSale { get; set; }
        public string? PaymentDetailHash { get; set; }
        public int PaymentType { get; set; }

    }
}
