using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission3
{
    internal class Invoice
    {
        public string InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string ShippingCity { get; }
        public decimal TotalAmount { get; }
    internal Invoice(string invoiceId, string customerName, string customerEmail, string shippingCity, decimal totalAmount)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            ShippingCity = shippingCity;
            TotalAmount = totalAmount;
        }
    }
    }
