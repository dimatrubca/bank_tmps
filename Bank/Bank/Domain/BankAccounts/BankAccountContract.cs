using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.BankAccounts
{
     class BankAccountContract : IPrototype
     {
          public string ClientId { get; set; }
          public DateTime Timestamp { get; set; }
          public string BankAcountId { get; set; }

          public IPrototype Clone()
          {
               throw new NotImplementedException();
          }
     }
}
