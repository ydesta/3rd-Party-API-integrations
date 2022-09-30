using CUSTOR.PaymentIntegrationWithDerash.CORE.Interface;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CUSTOR.PaymentIntegrationWithDerash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository) 
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("dailyPayment")]
        public void DailyTaxPayerPayment()
        {
            RecurringJob.AddOrUpdate(() => paymentRepository.GetAllPaymentByStatus(), Cron.Hourly);
        }
    }
}
