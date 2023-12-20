using HalkBank.UnitTests.ConsoleApp.Attributes;
using HalkBank.UnitTests.ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.Accounting
{
  public class Account
  {
    public string AccountNumber { get; init; }

    public decimal Balance { get; private set; }

    public string Currency { get; init; } // TL,$,Euro

    public DateTime CreatedAt { get; init; }

    public string? CloseReason { get; private set; }

    public DateTime? ClosedAt { get; private set; }

    public bool Closed { get; private set; }


    // para çekme ve para yatırma işlemi sırasında oluşan hesap detayı.(Hesap Dökümü)
    private List<AccountTransaction> transactions = new List<AccountTransaction>();

    public IReadOnlyCollection<AccountTransaction> Transactions => transactions;


    public Account(string accountNumber, string currency)
    {
      AccountNumber = accountNumber;
      Balance = 0;
      Currency = currency;
      CreatedAt = DateTime.Now;
    }

    public void CloseAccount(string closeReason)
    {
      ClosedAt = DateTime.Now;
      CloseReason = closeReason;
      Closed = true;
      //AccountNumber = "32423432";
    }

    /// <summary>
    /// Hesaptan para çekme işlemi
    /// Günlük 30.000 TL üstü para çekilemesin (BalanceUnSufficientException)
    /// Kapalı Hesap üzerinden para çekilemez (AccountClosedException)
    /// Bakiye çekilecek tutardan küçük ise para çekilemez (BalanceUnSufficientException)
    /// </summary>
    /// <param name="amount"></param>
    [CustomException]
    public void WithDraw(decimal amount)
    {

      // gün içerisinde yapılan bakiye işlemleri
      var dailyUsageCost = transactions.Where(x => x.TransactionAt.Date == DateTime.Now.Date).Sum(x => x.Amount);

      if ((dailyUsageCost + amount) > 30000)
        throw new BalanceUnSufficientException("Günlük Para Çekme Limitini aştınız");

      if (Closed)
        throw new AccountClosedException();

      if (Balance < amount)
        throw new BalanceUnSufficientException();

      Balance -= amount;
      transactions.Add(new AccountTransaction(AccountNumber, (int)TransactionType.WithDraw, amount));



    }

    /// <summary>
    /// Para yatırma methodu
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount)
    {
      Balance += amount;
    }
  }
}
