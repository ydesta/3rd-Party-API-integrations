using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Entity
{
    public class TaxPayerGracePeriod
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public string? Description { get; set; }
    }
}
