using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
    interface ICard
    {
        public decimal Balance { get; set; }

        public void TransferMoney(Card card, decimal amount);

    }
}
