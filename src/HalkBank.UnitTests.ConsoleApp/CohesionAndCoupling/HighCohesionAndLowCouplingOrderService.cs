using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling
{
  // soyut yapılar ile çalışarak sınıfların birbirine olan bağımlılıklarını ortadan kaldırmaya çalışacağız.
  public interface IEmailService
  {
    void SendEmail(string to, string message);
  }

  public class VodafoneService : IEmailService
  {
    public void SendEmail(string to, string message)
    {
      Console.WriteLine("Vodafone");

    }
  }

  public class TurkcellService : IEmailService
  {
    public void SendEmail(string to, string message)
    {
      Console.WriteLine("Turkcell");

    }
  }

  public interface IRepository<TEntity>
  {
    void Save(TEntity entity);
  }

  public class EFOrderRepository : IRepository<Order>
  {
    public void Save(Order entity)
    {
      Console.WriteLine("EF");
    }
  }

  public class AdoNetOrderRepository : IRepository<Order>
  {
    public void Save(Order entity)
    {
      Console.WriteLine("AdoNet");
    }
  }

  public class PromationDiscountService : IDiscount
  {
    public void ApplyPromationCode(string code)
    {
      Console.WriteLine("Promosyon uygulandı");
    }
  }

  public interface IDiscount
  {
    void ApplyPromationCode(string code);
  }

  // LowCouplingOrderService içerisinde aşağıdaki herhangi bir interfaceden implemente olan bir sınıf instance olarak gönderilebilir. Buda sınıflar arasında zayıf bağlılık derecesini gösterir.
  public class HighCohesionAndLowCouplingOrderService
  {
    private readonly IEmailService emailService;
    private readonly IRepository<Order> repository;
    private readonly IDiscount discount;

    // SOLID:DIP prensibinin örnek kullanımı


    // bunlar LowCouplingOrderService order servis için dışarıdan gönderilmesi gereken bağımlılıklardır.
    // DI (Dependecy Injection Design Patter, Constructor üzerinden servisleri sınıfa enjecte ettik.)
    public HighCohesionAndLowCouplingOrderService(IEmailService emailService, IRepository<Order> repository, IDiscount discount)
    {
      this.emailService = emailService;
      this.repository = repository;
      this.discount = discount;
    }

    public void SubmitOrder(Order order, string code)
    {
      discount.ApplyPromationCode(code);
      this.repository.Save(order);
      this.emailService.SendEmail(order.CustomerId, "Sipariş alındı");
    }



  }
}
