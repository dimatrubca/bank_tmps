using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
     class DebitCard : Card
     {
          public DebitCard(Client owner, Tier tier, decimal transactionFee, decimal annualFee, decimal balance) : base(owner, tier, transactionFee, annualFee, balance)
          {
          }

          public override decimal SpendingBalance()
          {
               return Balance;
          }
     }
}
