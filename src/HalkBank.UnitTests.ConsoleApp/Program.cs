// See https://aka.ms/new-console-template for more information
using Autofac;
using Autofac.Extras.DynamicProxy;
using HalkBank.UnitTests.ConsoleApp;
using HalkBank.UnitTests.ConsoleApp.Accounting;
using HalkBank.UnitTests.ConsoleApp.Attributes;
using HalkBank.UnitTests.ConsoleApp.CohesionAndCoupling;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;


// Instance alma işlemini AutoFac üzerine bıraktık. IoC yapısı kullandık.
var builder = new ContainerBuilder();
builder.RegisterModule(new ServiceRegistrationModule());

var container = builder.Build(); // uygulamanın servicelerini çözümlemek için hazırladık



Console.WriteLine("Hello, World!");

Customer customer = new Customer(firstName:"ALi",lastname:"TAN");
customer.CreateNewAccount(accountNumber:"678-34576-456",currency:"TL");
customer.CloseAccount(accountNumber:"678-34576-456",closeReason: "Yeni İş");

// customer.Accounts.Add() //  kod çağrılmasını bozacak kullanımlardan izole olmalıdır. Add ReadOnly olduğu için yapamadık.
var customerAccount = customer.Accounts.FirstOrDefault(x => x.AccountNumber == "678-34576-456");

if(customerAccount is not null)
{
  //customerAccount.WithDraw(5000); // 5000 TL para çek.,
}


var acc = new Account("324234-234-324324", "$");
// acc.Balance = 5500; // Developer tarafından balance değeri değiştirilememlidir.
acc.CloseAccount("Bilinmiyor");
// acc.ClosedAt = DateTime.Now; yukarıdaki kod bloğu içine encapsulate edildiği için developer bunu yapmamalı, yanlış kullanımların önüne geçtik.


#region HighCohesionSample

var highCohesionOrderService = new HighCohesionOrderService();
highCohesionOrderService.SubmitOrder(order:new Order("CAN"), promationCode: "324234");


#endregion


#region HighCohesionLowCouplingSample

var vodafone = new VodafoneService();
var efRepo = new EFOrderRepository();
var proDis = new PromationDiscountService();

var service = new HighCohesionAndLowCouplingOrderService(emailService: vodafone, efRepo, proDis);
service.SubmitOrder(order:new Order("ALI"),code: "234324");

var turkcell = new TurkcellService();
var adoNetRepo = new AdoNetOrderRepository();

var service2 = new HighCohesionAndLowCouplingOrderService(emailService: turkcell, adoNetRepo, proDis);
service2.SubmitOrder(order: new Order("ALI"), code: "234324");


#endregion



#region IoC

// Register edilen serviceleri ise burada çağırdık.
// Değeri Key üzerinden çöz.
// Bir interface birden fazla sınıftan implemente olduğu durumlarda key üzerinden service çözümleme yapılabilir.

Console.WriteLine("Hangi Email Provider üzerinden Mail atmak istersiniz, Turkcell/Vodafone");
string providerKey = Console.ReadLine();

var email = container.ResolveKeyed<IEmailService>(providerKey);
var repo = container.Resolve<IRepository<Order>>();
var discount = container.Resolve<IDiscount>();


var hcS = new HighCohesionAndLowCouplingOrderService(email,repo,discount);
hcS.SubmitOrder(new Order("ALI"), "324234");

#endregion







