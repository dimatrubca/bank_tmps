using BankApp.Domain.Clients;

namespace BankApp.Domain.BankAcounts
{
     class BankAccount
     {
          public int Id { get; set; }
          public Client Owner { get; set; }
          public decimal Balance { get; set; }

     }
}
