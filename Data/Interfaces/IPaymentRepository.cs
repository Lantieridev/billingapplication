using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BillingApplication.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillingApplication.Data.Interfaces
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
        Task<PaymentMethod> GetByIdAsync(int id);
        Task<IEnumerable<PaymentMethod>> GetAllAsync();
        Task<int> AddAsync(PaymentMethod paymentMethod);
        Task UpdateAsync(PaymentMethod paymentMethod);
        Task DeleteAsync(int id);
        Task<PaymentMethod> GetByNameAsync(string name);
    }
}
