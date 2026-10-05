using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission3
{
    internal class ComposedInvoiceBuilder
    {
        private string _invoiceId;

        public AddressBuilder ShippingAddress { get; } = new AddressBuilder();
        public AddressBuilder BillingAddress { get; } = new AddressBuilder();

        public ComposedInvoiceBuilder(string invoiceId)
        {
            _invoiceId = invoiceId;
        }

        public ComposedInvoiceBuilder SetId(string id)
        {
            _invoiceId = id;
            return this;
        }

        public ComposedInvoiceBuilder WithShipping(Action<AddressBuilder> addressAction)
        {
            addressAction(ShippingAddress);
            return this;
        }
    }
}
