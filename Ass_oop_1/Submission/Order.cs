using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Submission
{
    internal class Order
    {
        public int OrderId { get; }
        public string OrderDate { get; }
        public bool IsPaid { get; private set; }
        public Customer Customer { get; }
        public List<OrderLine> Lines { get; } = new List<OrderLine>();

        public Order(int orderId, Customer customer, string date)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDate = date;
            IsPaid = false;
        }

        public void AddLine(Product product, int quantity)
        {
            if (!IsPaid && quantity > 0 && product.ProductStock >= quantity)
            {
                product.DecreaseStock(quantity);
                Lines.Add(new OrderLine(product, quantity));
            }
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var line in Lines)
            {
                total += line.GetLineTotal();
            }

            if (Customer.IsVip)
            {
                total = total * 0.90;
            }

            return total;
        }

        public void MarkAsPaid()
        {
            if (Lines.Count > 0)
            {
                IsPaid = true;
            }
        }
    }
}
