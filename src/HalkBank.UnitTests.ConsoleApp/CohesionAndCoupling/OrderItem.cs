using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling
{
  public class OrderItem
  {
    public int Quantity { get; init; }
    public string ProductId { get; init; }
    public decimal ListPrice { get; init; }

    public OrderItem(int quantity, string productId, decimal listPrice)
    {
      this.Quantity = quantity;
      this.ProductId = productId;
      this.ListPrice = listPrice;
    }
  }
}
