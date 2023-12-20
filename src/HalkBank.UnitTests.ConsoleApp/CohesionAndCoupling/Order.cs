using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling
{
  public class Order
  {
    public Guid OrderCode { get; init; }
    public DateTime OrderDate { get; init; }
    public string CustomerId { get; init; }

    private List<OrderItem> items = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> Items => items;

    public Order(string customerId)
    {
      OrderCode = Guid.NewGuid();
      OrderDate = DateTime.Now;
      CustomerId = customerId;
    }

    /// <summary>
    /// Siparişe yeni bir item ekleme işlemi için yaptık
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="ProductId"></param>
    /// <param name="listPrice"></param>
    public void AddItem(int quantity,string ProductId,decimal listPrice)
    {
      var item = new OrderItem(quantity, ProductId, listPrice);
    }



  }
}
