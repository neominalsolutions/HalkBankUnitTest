using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HalkBank.UnitTests.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountsController : ControllerBase
  {

    [HttpPost]
    [CustomException] // AOP programlama yapısını kurarak. Controller seviyesinde hataları merkezi olarak yönetmek için IExceptionFilter interfaceden yararlanılıyor.
    public IActionResult WithDraw()
    {

      Account account = new Account("32432-324324-23432", "TL");
      account.WithDraw(5000);

      // clean code açısından yanlış bir kullanım örneği

      //try
      //{
      //  Account account = new Account("32432-324324-23432", "TL");
      //  account.WithDraw(5000);
      //}
      //catch (Exception)
      //{

      //  throw;
      //}


      return Ok();
    }
  }
}
