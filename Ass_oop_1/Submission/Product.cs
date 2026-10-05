using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission
{
    internal class Product
    {

  public    int    ProductIds      { get; }
  public    string ProductName     { get; }
  public    double ProductPrice    { get; private set; }
  public    int    ProductStock    { get; private set; }

        public Product(int id, string name, double price, int stock)
        {
            ProductIds = id;
            ProductName = name;
            ProductPrice = price;
            ProductStock = stock;
        }
        public void UpdatePrices(double newPrice)
        {
            if(newPrice > 0) { ProductPrice = newPrice; }
        }
        public void DecreaseStock(int quantity) 
        { 
            if(ProductStock >= quantity) ProductStock -= quantity;
        
        }
    }
}
