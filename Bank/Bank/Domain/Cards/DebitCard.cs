using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
     class DebitCard : Card
     {
          public DebitCard(Client owner, CardType type, decimal transactionFee, decimal annualFee, decimal balance) : base(owner, type, transactionFee, annualFee, balance)
          {
          }

          public override decimal SpendingBalance()
          {
               return Balance;
          }
     }
}
