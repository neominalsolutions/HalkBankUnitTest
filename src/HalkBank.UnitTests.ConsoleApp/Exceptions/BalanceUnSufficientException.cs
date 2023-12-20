using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.Exceptions
{
  // checked exception => clean code açısından hata durumlarının kullanı taraflı yönetimi
  public class BalanceUnSufficientException:Exception
  {
    public BalanceUnSufficientException(string message = "Bakiye Yetersiz") : base(message)
    {

    }
  }
}
