using CUSTOR.PaymentIntegrationWithDerash.CORE.Entity;
using CUSTOR.PaymentIntegrationWithDerash.CORE.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Repository
{
    public class TaxPayerGracePeriodRepository : GenericRepository<TaxPayerGracePeriod>, ITaxPayerGracePeriodRepository
    {
        public TaxPayerGracePeriodRepository(TaxPayerDbContext context) : base(context)
        {

        }
        public int GetGracePeriod()
        {
            var taxPayerGracePeriod =  _context.TaxPayerGracePeriod.FirstOrDefault();
            return taxPayerGracePeriod.NumberOfDays;
        }
    }
}
