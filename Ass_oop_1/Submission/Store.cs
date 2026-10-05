namespace Submission
{
    internal class Store
    {
        public List<Customer> Customers { get; } = new List<Customer>();
        public List<Product> Products { get; } = new List<Product>();
        public List<Order> Orders { get; } = new List<Order>();

        public Customer FindCustomerById(int id)
        {
            foreach (var c in Customers)
            {
                if (c.Id == id) return c;
            }
            return null;
        }

        public Product FindProductById(int id)
        {
            foreach (var p in Products)
            {
                if (p.ProductIds == id) return p;
            }
            return null;
        }

        public Order FindOrderById(int id)
        {
            foreach (var o in Orders)
            {
                if (o.OrderId == id) return o;
            }
            return null;
        }

        public void AddCustomer(int id, string name, string email, string city, bool isVip)
        {
            if (FindCustomerById(id) != null)
            {
                Console.WriteLine("ERROR: Customer already exists.");
                return;
            }
            Customers.Add(new Customer(id, name, email, city, isVip));
        }

        public void AddProduct(int id, string name, double price, int stock)
        {
            if (FindProductById(id) != null)
            {
                Console.WriteLine("ERROR: Product already exists.");
                return;
            }
            Products.Add(new Product(id, name, price, stock));
        }

        public Order CreateOrder(int orderId, int customerId, string date)
        {
            if (FindOrderById(orderId) != null)
            {
                Console.WriteLine("ERROR: Order already exists.");
                return null;
            }

            Customer customer = FindCustomerById(customerId);
            if (customer == null)
            {
                Console.WriteLine("ERROR: Customer not found.");
                return null;
            }

            Order newOrder = new Order(orderId, customer, date);
            Orders.Add(newOrder);
            return newOrder;
        }


        public void PrintCustomers()
        {
            Console.WriteLine($"\n=== CUSTOMERS ({Customers.Count}) ===");
            foreach (var c in Customers)
            {
                Console.WriteLine($"#{c.Id}  {c.Name}  <{c.Email}>  {c.City}  vip={(c.IsVip ? "yes" : "no")}");
            }
        }

        public void PrintProducts()
        {
            Console.WriteLine($"\n=== PRODUCTS ({Products.Count}) ===");
            foreach (var p in Products)
            {
                Console.WriteLine($"#{p.ProductIds}  {p.ProductName}  price={p.ProductPrice:F2}  stock={p.ProductStock}");
            }
        }

        public void PrintAllOrders()
        {
            Console.WriteLine($"\n=== ALL ORDERS ({Orders.Count}) ===");
            foreach (var o in Orders)
            {
                PrintOrderDetails(o.OrderId);
            }
        }

        public void PrintOrderDetails(int orderId)
        {
            Order order = FindOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine($"ERROR: order id {orderId} not found.");
                return;
            }

            Console.WriteLine($"\n=== ORDER #{order.OrderId} ===");
            Console.WriteLine($"Date: {order.OrderDate}");
            Console.WriteLine($"Customer: {order.Customer.Name} (#{order.Customer.Id})");
            Console.WriteLine($"Paid: {(order.IsPaid ? "yes" : "no")}");
            Console.WriteLine("Lines:");

            foreach (var line in order.Lines)
            {
                double lineTotal = line.GetLineTotal();
                Console.WriteLine($"  - {line.Product.ProductName}  x{line.Quantity}  @{line.Product.ProductPrice}  = {lineTotal:F2}");
            }

            Console.WriteLine($"TOTAL: {order.CalculateTotal():F2}");
        }

        public double GetTotalPaidSales()
        {
            double sum = 0.0;
            foreach (var o in Orders)
            {
                if (o.IsPaid)
                {
                    sum += o.CalculateTotal();
                }
            }
            return sum;
        }
    }
}