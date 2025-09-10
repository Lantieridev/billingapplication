using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingApplication.Domain.Entities;

namespace BillingApplication.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        // Navigation properties (solo para uso en la aplicación)
        public Customer Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }
}
