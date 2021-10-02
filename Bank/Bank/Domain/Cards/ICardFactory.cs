using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Cards
{
     interface ICardFactory
     {
          public ICreditCard CreateCreditCard(Bank bank, Client owner);
          public IDebitCard CreateDebitCard(Bank bank, Client owner);
     }
}
