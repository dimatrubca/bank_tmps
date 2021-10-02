using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Cards
{
     class PlatinumCardFactory : ICardFactory
     {
          public ICreditCard CreateCreditCard(Bank bank, Client owner)
          {
               return new CreditCard(bank, owner, CardType.Platinum, 0.015m, 450, 0, 1, 10000);
          }

          public IDebitCard CreateDebitCard(Bank bank, Client owner)
          {
               return new DebitCard(bank, owner, CardType.Platinum, 0.015m, 450, 0);
          }
     }
}
