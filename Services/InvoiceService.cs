﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillingApplication.Domain.Entities;
using BillingApplication.Services.Interfaces;
using BillingApplication.Data.Interfaces;

namespace BillingApplication.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;  // ← INTERFAZ ESPECÍFICA

        public InvoiceService(IInvoiceRepository invoiceRepository, IProductRepository productRepository)
        {
            _invoiceRepository = invoiceRepository;
            _productRepository = productRepository;
        }

        // ... el resto del código permanece igual ...
        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice, List<InvoiceDetail> details)
        {
            try
            {
                // Generar número de factura
                invoice.NumeroFactura = await _invoiceRepository.GenerateNextInvoiceNumberAsync();

                // Calcular totales
                CalculateInvoiceTotals(invoice, details);

                // Crear factura
                invoice.Id = await _invoiceRepository.AddAsync(invoice);

                // Agregar detalles y actualizar stock
                foreach (var detail in details)
                {
                    detail.FacturaId = invoice.Id;
                    await _invoiceRepository.AddInvoiceDetailAsync(detail);
                    await _invoiceRepository.UpdateStockAsync(detail.ProductoId, detail.Cantidad, "DECREMENT");
                }

                return await _invoiceRepository.GetInvoiceWithDetailsAsync(invoice.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating invoice: {ex.Message}", ex);
            }
        }

        private void CalculateInvoiceTotals(Invoice invoice, List<InvoiceDetail> details)
        {
            invoice.Subtotal = 0;
            foreach (var detail in details)
            {
                detail.Subtotal = detail.Cantidad * detail.PrecioUnidad;
                invoice.Subtotal += detail.Subtotal;
            }
            invoice.Total = invoice.Subtotal;
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _invoiceRepository.GetInvoiceWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }

        public async Task<string> GenerateNextInvoiceNumberAsync()
        {
            return await _invoiceRepository.GenerateNextInvoiceNumberAsync();
        }
    }
}