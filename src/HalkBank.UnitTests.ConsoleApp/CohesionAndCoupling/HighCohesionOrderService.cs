using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling
{
  public class OrderRepository
  {
    public void Save(Order order)
    {
      Console.Write("Sipariş girildi");
    }
  }
  public class DiscountService
  {
    public void ApplyDiscount(string promationCode)
    {
      if (!string.IsNullOrEmpty(promationCode))
        Console.WriteLine("Indirim Yapıldı");
    }
  }
  public class EmailService
  {
    public void SendEmail(string to, string message)
    {
      Console.WriteLine(message);
    }
  }

  // Top Level Class (Süt Seviye class içerisine alt seviye işlem classlarını encasulate edip çalışacak bir yöneteme göre geliştir.)

  // Soru: Ya EmailService olarak farklı bir alt yapıya geçmem gerekirse bu kod farklı bir alt yapı ile çalışmayı destekliyor mu?
  // Ya Farklı bir database teknolojisine (Postgres) kayıt atacak şekilde bir durum ortaya çıksa uygulama buna kod değişikliği yapmadan cevap verebiliyor mu?
  public class HighCohesionOrderService
  {
    // Sub Level Class
    private readonly OrderRepository orderRepository = new OrderRepository();
    private readonly EmailService emailService = new EmailService();
    private readonly DiscountService discountService = new DiscountService();
    // FACADA DESIGN PATTERN

    // Sorumluklar doğru ayrıldığında SOLID: SRP (Single Responsibilty uygulanmış oldu).
    public void SubmitOrder(Order order, string promationCode)
    {
      discountService.ApplyDiscount(promationCode);
      orderRepository.Save(order);
      emailService.SendEmail(order.CustomerId, "Sipariş oluştu");
    }
  }

  // HighCohesionOrderService ile alt sevisler birbirleri ise Tight Coupled bir bağımlılığa sahip.
}
