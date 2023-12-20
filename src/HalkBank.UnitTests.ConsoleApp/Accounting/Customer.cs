using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalkBank.UnitTests.ConsoleApp.Accounting
{
  // Domain Centric (Associations,Property,Event,Method,Field) Object yapıları burdaki tanımlanan classlara örnek verilebilir. veya Data Centric (Data Structure), Class içerisinde sadece property barındırır.
  public class Customer // Customer class Account için Information Expert sorumluluğunda hesap açılış kapanış durumlarını yönetiyor.
  {
    public string FirstName { get; init; } // setter sadece constructor setter
    public string LastName { get; init; }
    // Accounts dizisini dışarı sadece readOnly olarak açtık.

    // field dışarı açmadık
    private List<Account> accounts = new List<Account>(); // müşteri banka hesapları
    public IReadOnlyList<Account> Accounts => accounts;

    public string FullName { get {
        return $"{FirstName} {LastName}";
      } 
    }

    // init ile tanımlanan setterlar constructor üzerinden geçmek zorunda olduğumuz parametreler.
    public Customer(string firstName, string lastname)
    {
      FirstName = firstName.Trim();
      LastName = lastname.Trim().ToUpper();
    }

    /// <summary>
    /// Müşteri Yeni Hesap açılışını yaptık
    /// </summary>
    /// <param name="accountNumber"></param>
    public void CreateNewAccount(string accountNumber, string currency)
    {
      accounts.Add(new Account(accountNumber, currency));
    }

    /// <summary>
    /// Müşteri Hesabı Kapama işlemi
    /// </summary>
    /// <param name="accountNumber">Hesap Numarası</param>
    /// <param name="closeReason">Neden Kapandı</param>
    /// <exception cref="Exception"></exception>
    public void CloseAccount(string accountNumber, string closeReason)
    {
      var account = accounts.Find(x => x.AccountNumber == accountNumber);

      if (account is null)
        throw new Exception("Hesap bulunamadı");

      account.CloseAccount(closeReason);
    }

  }
}
