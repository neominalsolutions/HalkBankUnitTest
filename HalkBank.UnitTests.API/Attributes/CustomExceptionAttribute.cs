using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.API
{

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
  public class CustomExceptionAttribute : Attribute, IExceptionFilter
  {
    public void OnException(ExceptionContext context)
    {
      Console.WriteLine("Hata" + context.Exception.Message);
    }
  }
}
