using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Cards
{
     class CreditCard : Card, ICreditCard
     {
          public CreditCard(Bank issuer, Client owner, CardType type, 
               decimal transactionFee, decimal annualFee, decimal balance,
               decimal bonusPoints, decimal spendingLimit) : base(issuer, owner, type, transactionFee, annualFee, balance)
          {
               BonusPoints = bonusPoints;
               SpendingLimit = spendingLimit;
          }

          public decimal BonusPoints { get; set; }
          public decimal SpendingLimit { get; set; }

          public override decimal SpendingBalance() {
               return Balance + SpendingLimit;
          }
     }
}
