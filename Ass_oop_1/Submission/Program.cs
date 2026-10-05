namespace Submission
{
    internal class Program
    {
        static void SeedData(Store store)
        {
            store.AddCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
            store.AddCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
            store.AddCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

            store.AddProduct(101, "USB Cable", 50.0, 100);
            store.AddProduct(102, "Wireless Mouse", 250.0, 40);
            store.AddProduct(103, "Mechanical Keyboard", 1200.0, 15);
            store.AddProduct(104, "Laptop Stand", 400.0, 25);
        }

        static void RunDemo(Store store)
        {
            Order o1 = store.CreateOrder(1001, 1, "2026-09-15");
            if (o1 != null)
            {
                o1.AddLine(store.FindProductById(101), 2);
                o1.AddLine(store.FindProductById(102), 1);
                o1.MarkAsPaid();
            }

            Order o2 = store.CreateOrder(1002, 2, "2026-09-15");
            if (o2 != null)
            {
                o2.AddLine(store.FindProductById(103), 1);
                o2.AddLine(store.FindProductById(104), 1);
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\n---------- MENU ----------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("OOP Order System (C# Conversion)\n");
            Store store = new Store();

            SeedData(store);
            RunDemo(store);

            store.PrintCustomers();
            store.PrintProducts();
            store.PrintAllOrders();

            Console.WriteLine($"\nPaid sales total after demo: {store.GetTotalPaidSales():F2}");

            int choice = -1;
            while (choice != 0)
            {
                PrintMenu();
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (choice == 1)
                {
                    store.PrintCustomers();
                }
                else if (choice == 2)
                {
                    store.PrintProducts();
                }
                else if (choice == 3)
                {
                    store.PrintAllOrders();
                }
                else if (choice == 4)
                {
                    Console.Write("Order id: ");
                    int id = int.Parse(Console.ReadLine());
                    store.PrintOrderDetails(id);
                }
                else if (choice == 5)
                {
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine());
                    Console.Write("Customer id: ");
                    int customerId = int.Parse(Console.ReadLine());
                    Console.Write("Date (YYYY-MM-DD): ");
                    string date = Console.ReadLine();
                    store.CreateOrder(orderId, customerId, date);
                }
                else if (choice == 6)
                {
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine());
                    Order order = store.FindOrderById(orderId);
                    if (order == null)
                    {
                        Console.WriteLine("ERROR: Order not found.");
                        continue;
                    }

                    Console.Write("Product id: ");
                    int prodId = int.Parse(Console.ReadLine());
                    Product product = store.FindProductById(prodId);
                    if (product == null)
                    {
                        Console.WriteLine("ERROR: Product not found.");
                        continue;
                    }

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    order.AddLine(product, qty);
                }
                else if (choice == 7)
                {
                    Console.Write("Order id: ");
                    int orderId = int.Parse(Console.ReadLine());
                    Order order = store.FindOrderById(orderId);
                    if (order != null)
                    {
                        order.MarkAsPaid();
                        Console.WriteLine("Order marked as paid.");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Order not found.");
                    }
                }
                else if (choice == 8)
                {
                    Console.WriteLine($"Paid sales total: {store.GetTotalPaidSales():F2}");
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Bye.");
                }
                else
                {
                    Console.WriteLine("Unknown choice.");
                }
            }
        }
    }
}