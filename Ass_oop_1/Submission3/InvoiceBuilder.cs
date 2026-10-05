using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission3
{
    internal class InvoiceBuilder
    {
        private string _invoiceId;
        private string _customerName;
        private string _customerEmail;
        private string _shippingCity;
        private decimal _totalAmount;

        public InvoiceBuilder(string invoiceId, string customerName)
        {
            if (string.IsNullOrEmpty(invoiceId)) throw new ArgumentException("Id is required");
            if (string.IsNullOrEmpty(customerName)) throw new ArgumentException("Name is required");

            _invoiceId = invoiceId;
            _customerName = customerName;
        }

        public InvoiceBuilder WithEmail(string email)
        {
            _customerEmail = email;
            return this;
        }

        public InvoiceBuilder WithShippingCity(string city)
        {
            _shippingCity = city;
            return this;
        }

        public InvoiceBuilder WithTotal(decimal total)
        {
            _totalAmount = total;
            return this;
        }

        public Invoice Build()
        {
            if (string.IsNullOrEmpty(_shippingCity))
                throw new InvalidOperationException("Shipping city cannot be empty!");

            return new Invoice(_invoiceId, _customerName, _customerEmail, _shippingCity, _totalAmount);
        }
    }
}
