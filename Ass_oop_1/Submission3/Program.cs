namespace Submission3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice1 = new InvoiceBuilder("INV-001", "Mariam Hamdi")
                .WithEmail("mariam@test.com")
                .WithShippingCity("Alexandria")
                .WithTotal(500m)
                .Build();

           
            Invoice invoice2 = new ComposedInvoiceBuilder("INV-002")
                .WithShipping(addr => addr.WithStreet("123 Street").WithCity("Alexandria"))
                .WithBilling(addr => addr.WithStreet("456 Street").WithCity("Cairo"))
                .Build(); 
        }
    }
}