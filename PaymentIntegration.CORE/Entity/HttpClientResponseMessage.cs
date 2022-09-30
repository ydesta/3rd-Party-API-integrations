using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Entity
{
    public class HttpClientResponseMessage
    {
        [Key]
        public int Id { get; set; }
        public string? OrderNo { get; set; }
        public string? StatusMessage { get; set; }
        public string? MessageDescription { get; set; }
        public DateTime RegisterDate { get; set; }
        public int StatusCode { get; set; }        
    }
}
