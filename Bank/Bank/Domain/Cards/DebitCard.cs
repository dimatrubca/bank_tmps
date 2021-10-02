using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Cards
{
     class DebitCard : Card, IDebitCard
     {
          public DebitCard(Bank issuer, Client owner, CardType type, decimal transactionFee, decimal annualFee, decimal balance) : base(issuer, owner, type, transactionFee, annualFee, balance)
          {
          }

          public override decimal SpendingBalance()
          {
               return Balance;
          }
     }
}
