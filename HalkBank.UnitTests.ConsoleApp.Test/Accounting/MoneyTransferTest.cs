using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HalkBank.UnitTests.ConsoleApp.Test.Accounting
{

  // UnitTest methodlarını içerisinde barındıracağımız class
  public class MoneyTransferTest
  {

    [Fact] // Test methodu parametresiz çalışacak ise kullanırız
    public void WithDrawWhenAccountIsClosed()
    {
      // Arrange => Setup işlemi
      HalkBank.UnitTests.ConsoleApp.Accounting.Account account = new ConsoleApp.Accounting.Account("324324-234324-43324","TL");
      account.CloseAccount("ForTestPurposes");


      // Act => Eyleme geçme test methodunu tetikleme
      account.WithDraw(1000);

      // Assert => Testen geçip geçmediğimizi kontrol aşaması 
      // ExpectedValue ile ActualValue üzerinden kontrol sağlanır.
      Assert.True(!account.Closed); // Hesap kapalı değilse para çekeriz kapalı ise testen kal.
    }


    /// <summary>
    /// 30.000 Günlük ödemenin kontrolünü yapan unitTest
    /// </summary>
    [Fact] // Günlük olarak 3 kez arka arkaya para çekme işlemini test edelim
    public void DailyWithDrawLimitCheck()
    {
      // Arrange
      HalkBank.UnitTests.ConsoleApp.Accounting.Account account = new ConsoleApp.Accounting.Account("324324-234324-43324", "TL");
      account.Deposit(100000);

      // Gün içerisinde 3 kez para çekeceğiz
      account.WithDraw(15000);
      account.WithDraw(8000);
      account.WithDraw(10000);

      // Assert
      Assert.Equal(67000, account.Balance);

    }

    [Theory] // test methodların InlineData da belirltilen sırada parametre dinamik olarak geçiliyor.
    [InlineData(1000,19000)]
    [InlineData(5000, 8000)]
    [InlineData(3000, 7000)]
    public void WithDrawCheckTestDiffirentParameters(decimal amount,decimal avaibleBalance)
    {
      //Arrange
      HalkBank.UnitTests.ConsoleApp.Accounting.Account account = new ConsoleApp.Accounting.Account("324324-234324-43324", "TL");
      account.Deposit(20000);

      // Act
      account.WithDraw(amount);

      // Assert
      Assert.Equal(avaibleBalance, account.Balance);

    }
  }
}
