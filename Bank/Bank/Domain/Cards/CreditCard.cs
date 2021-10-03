using BankApp.Domain.Credits;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
     class CreditCard : Card
     {
          public CreditCard(Client owner, CardType type, 
               decimal transactionFee, decimal annualFee, decimal balance,
               decimal bonusPoints, decimal spendingLimit) : base(owner, type, transactionFee, annualFee, balance)
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
