using CUSTOR.PaymentIntegrationWithDerash.CORE.Entity;
using CUSTOR.PaymentIntegrationWithDerash.CORE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Repository
{
    public class HttpClientResponseMessageRepository : GenericRepository<HttpClientResponseMessage>, IHttpClientResponseMessageRepository
    {
        public HttpClientResponseMessageRepository(TaxPayerDbContext context):base(context)
        {

        }

        public async Task Create(string OrderNo, string MessageDescription, int StatusCode, string StatusMessage)
        {
            var clientResponsesitenotfound = _context.HttpClientResponseMessage.Where(x => x.OrderNo == OrderNo && x.StatusCode == StatusCode).FirstOrDefault();
            if (clientResponsesitenotfound == null)
            {
                HttpClientResponseMessage sitenotfound = new HttpClientResponseMessage
                {
                    OrderNo = OrderNo,
                    RegisterDate = DateTime.Now,
                    MessageDescription = MessageDescription,
                    StatusCode = StatusCode,
                    StatusMessage = StatusMessage
                };
                _context.Add(sitenotfound);
                await _context.SaveChangesAsync();
            }
        }
    }
}
