using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE.Interface
{
    public interface IPaymentRepository:IGenericRepository<Payment>
    {
        Task GetAllPaymentByStatus();
    }
}
