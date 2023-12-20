using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.API
{
  public enum TransactionType
  {
    WithDraw = 100,
    Deposit = 200
  }

  public class AccountTransaction
  {
    public string AccountNumber { get; init; }
    public int TransactionType { get; init; }
    public decimal Amount { get; init; }

    public DateTime TransactionAt { get; private set; }


    public AccountTransaction(string accountNumber, int transactionType, decimal amount)
    {
      this.AccountNumber = accountNumber;
      this.TransactionType = TransactionType;
      this.Amount = amount;
      this.TransactionAt = DateTime.Now;
    }
  }
}
