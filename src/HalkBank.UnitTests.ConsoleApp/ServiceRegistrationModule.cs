using Autofac;
using HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp
{
  public class ServiceRegistrationModule:Module
  {
    // ContainerBuilder ile IoC Container'a service register edip bunları uygulamaya tanıtıcağız.
    protected override void Load(ContainerBuilder builder)
    {
      // IOc işlemi yaparken önce service registeration yapıyoruz.
      // burası uygulamadaki alt yapı değişikliklerini uyguladığımız dosyamız
      // böyle uygulamadaki alt yapı değişimlerini merkezi olarak yönetebiliriz.
      builder.RegisterType<TurkcellService>().As<IEmailService>().InstancePerDependency().Keyed<IEmailService>("Turkcell");
      builder.RegisterType<VodafoneService>().As<IEmailService>().InstancePerDependency().Keyed<IEmailService>("Vodafone");

      builder.RegisterType<EFOrderRepository>().As<IRepository<Order>>().InstancePerDependency();
      builder.RegisterType<PromationDiscountService>().As<IDiscount>().InstancePerDependency();

      base.Load(builder);
    }
  }
}
