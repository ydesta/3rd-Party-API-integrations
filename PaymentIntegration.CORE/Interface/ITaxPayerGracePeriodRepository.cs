using CUSTOR.PaymentIntegrationWithDerash.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Interface
{
    public interface ITaxPayerGracePeriodRepository : IGenericRepository<TaxPayerGracePeriod>
    {
       int GetGracePeriod();
    }
}
