using CUSTOR.PaymentIntegrationWithDerash.CORE.Entity;
using CUSTOR.PaymentIntegrationWithDerash.CORE.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly DerashApiConfig settings;
        private readonly TaxPayerDbContext context;
        private readonly ITaxPayerGracePeriodRepository taxPayerGracePeriodRepository;
        private readonly IHttpClientResponseMessageRepository clientResponseMessageRepository;

        public PaymentRepository(IOptions<DerashApiConfig> settings, TaxPayerDbContext context,
                                 ITaxPayerGracePeriodRepository taxPayerGracePeriodRepository,
                                 IHttpClientResponseMessageRepository clientResponseMessageRepository) : base(context)
        {
            this.settings = settings.Value;
            this.context = context;
            this.taxPayerGracePeriodRepository = taxPayerGracePeriodRepository;
            this.clientResponseMessageRepository = clientResponseMessageRepository;
        }
        public async Task GetAllPaymentByStatus()
        {
            try
            {
                var api_key = settings.API_KEY;
                var api_secret = settings.API_SECRET;
                var base_url = settings.BASE_URL;
                var numberOfdays = taxPayerGracePeriodRepository.GetGracePeriod();
                var addedDate = DateTime.Now.AddDays(numberOfdays);
                string date_due = addedDate.ToString("yyyy-MM-dd");
                var paymentViewModel = context.PaymentViewModel.FromSqlRaw("Select OrderNo,TeleNo ,Tin, TotalPayment,BusinessNameAmh,BankName,AccountNumber,CenterName,DatePrepared " +
                                                                           " from Payment where OrderNo is Not NULL and TeleNo is not NULL and Tin is not NULL and   " +
                                                                           "(BankName is not null or BankName != '') and AccountNumber is not null and TotalPayment is not null and " +
                                                                           "orderNo is not null and orderNo is not null and  DatePrepared > '2022-07-01' order by DatePrepared desc").ToList();
                List<BankReceipt> bankReceipts = new List<BankReceipt>();
                var paymentList = paymentViewModel.Select(x => new { x.OrderNo, x.TeleNo, x.BankName, x.AccountNumber,x.CenterName }).Distinct();
                BankReceipt banks = new BankReceipt();
                if (paymentViewModel.Count > 0)
                {
                    foreach (var item in paymentList)
                    {                        
                        banks = new BankReceipt();
                        var taxPays = paymentViewModel.Where(x => x.OrderNo == item.OrderNo && x.TeleNo == item.TeleNo).FirstOrDefault();
                        var DatePrepare = taxPays.DatePrepared;
                        var months = DatePrepare.Month;
                        var years = DatePrepare.Year;   
                        banks.amount_due = Decimal.ToDouble(taxPays.TotalPayment);
                        banks.bill_desc = $"Bank: {item.BankName} Account:{item.AccountNumber} Center:{item.CenterName} Period: {months} {years}";
                        banks.bill_id = item.OrderNo;
                        banks.customer_id = taxPays.Tin;
                        banks.due_date = date_due;
                        banks.email = "emailNofound99@gmail.com";
                        banks.mobile = item.TeleNo;
                        banks.name = taxPays.BusinessNameAmh;
                        banks.partial_pay_allowed = false;
                        banks.reason = "Tax Payer Payment";
                        using (var client = new HttpClient())
                        {
                            BankReceipt bank = new BankReceipt();
                            bank = banks;
                            var taxPayerPayment = JsonSerializer.Serialize(bank);
                            var requestContent = new StringContent(taxPayerPayment, Encoding.UTF8, "application/json");
                            client.DefaultRequestHeaders.Add("api-key", api_key);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Add("api-secret", api_secret);
                            var response = await client.PostAsync(base_url, requestContent);
                            string MessageDescription = await response.Content.ReadAsStringAsync();
                            string StatusMessage = "";
                            if ((int)response.StatusCode == 200)
                            {
                                //var payments = _context.Payment.Where(x => x.OrderNo == item.OrderNo).FirstOrDefault();
                                //if (payments != null)
                                //{
                                //    payments.DerashStatus = "UnPosted";
                                //    _context.Entry(payments).State = EntityState.Modified;
                                //    await _context.SaveChangesAsync();
                                //}
                                StatusMessage = "OK";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);
                            }
                            else if ((int)response.StatusCode == 401)
                            {
                                StatusMessage = "Unauthorized";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);
                               
                            }
                            else if ((int)response.StatusCode == 404)
                            {
                                StatusMessage = "Site Not Found";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);

                            }
                            else if ((int)response.StatusCode == 400)
                            {
                                StatusMessage = "Bad Request Enter Valid Input";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);
                            }
                            else if ((int)response.StatusCode == 500)
                            {
                                StatusMessage = "Server Not Availablet";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);

                            }
                            else if ((int)response.StatusCode == 403)
                            {
                                StatusMessage = "For bidden";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);
                            }
                            else if ((int)response.StatusCode == 409)
                            {
                                StatusMessage = "Data Duplication and Confilict";
                                await clientResponseMessageRepository.Create(item.OrderNo, MessageDescription, (int)response.StatusCode, StatusMessage);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
