using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Cards
{
     class GoldCardFactory : ICardFactory
     {
          public ICreditCard CreateCreditCard(Bank bank, Client owner)
          {
               return new CreditCard(bank, owner, CardType.Gold, 0.025m, 450, 0, 0.5m, 1000);
          }

          public IDebitCard CreateDebitCard(Bank bank, Client owner)
          {
               return new DebitCard(bank, owner, CardType.Gold, 0.025m, 450, 0);
          }
     }
}
