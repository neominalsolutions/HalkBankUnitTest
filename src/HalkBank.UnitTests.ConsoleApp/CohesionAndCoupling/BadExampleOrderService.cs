using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling
{
  public class BadExampleOrderService
  {
    // Cohesion için nesnenin ana sorumluluğu ne diye soralım ?
    // Nesnenin safdece tek bir sorumluluğu olmalı ?
    // Bir sınıfın kendisi dışında extra sorumlulukları varsa o zaman cohesion düşük bir sınıf ortaya çıkmış oluyor.
    // Acaba bu sorumluluklar başka sınıfın içeriisnde de çağırılabilir mi? Yani kodda kendimiz tekrar edecekmiyiz. DRY Dont Repeat Yourself.
    // Ana sorumlulk sipariş başlatan SubmitOrderMethodu
    public void SubmitOrder(Order order, string promationCode)
    {
      // Promosyon kod varsa indirim yap
      // Orderları db save et
      // Siparişi veren müşteriye sipariş kodunu takip etmek için mail at.
      ApplyDiscount(promationCode);
      Save(order);
      SendEmail(order.CustomerId, "Sipariş oluştu");
    }

    private void ApplyDiscount(string promationCode)
    {
      if(!string.IsNullOrEmpty(promationCode))
       Console.WriteLine("Indirim Yapıldı");
    }

    private void Save(Order order)
    {
      Console.Write("Sipariş girildi");
    }

    private void SendEmail(string customerId,string message)
    {
      Console.WriteLine("No Sipariş oluştu");
    }
  }
}
