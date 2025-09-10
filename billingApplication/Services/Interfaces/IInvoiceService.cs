using BillingApplication.Data.Interfaces;
using BillingApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using 

namespace BillingApplication.Services.Interfaces
{
    public interface IInvoiceService : IRepository<Invoice>
    {
        Task<Invoice> CreateInvoiceAsync(Invoice invoice, List<InvoiceDetail> details);
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<string> GenerateNextInvoiceNumberAsync();
    }
}