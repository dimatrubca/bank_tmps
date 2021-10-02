using Bank.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain
{
     class Client
     {
          public string Id { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public int CashAmount { get; set; }
          public List<BankAccountContract> Documents { get; set; }
     }
}
