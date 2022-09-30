using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE
{
    public class BaseEntity
    {
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedUserId { get; set; }
        public string? UpdatedUserId { get; set; }
        public string? CreatedBy { get; set; }
        public int? CenterId { get; set; }
        public string? CenterName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
