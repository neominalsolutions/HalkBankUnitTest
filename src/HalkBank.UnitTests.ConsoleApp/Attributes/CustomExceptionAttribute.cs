using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.Attributes
{

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
  public class CustomExceptionAttribute : Attribute, IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
      Console.WriteLine("Hata:" + (invocation as Exception).Message);
    }

  
  }
}
