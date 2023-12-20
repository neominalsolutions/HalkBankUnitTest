using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.API
{
  public class AccountClosedException:Exception
  {
    public AccountClosedException(string message="Hesap kullanıma kapalı"):base(message)
    {

    }
  }
}
