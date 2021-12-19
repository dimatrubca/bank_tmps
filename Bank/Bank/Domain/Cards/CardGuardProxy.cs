using System;
using System.Collections.Generic;

namespace BankApp.Domain.Cards
{
    class CardGuardProxy : ICard
    {
        private static List<string> blackList;
        private ICard _card;

        static CardGuardProxy()
        {
            blackList = new List<string> { "1232323567", "12345123" };
        }

        public CardGuardProxy(ICard card)
        {
            _card = card;
        }

        public void TransferMoney(Card receiverCard, decimal amount)
        {
            if (!blackList.Contains(receiverCard.Owner.Id))
            {
                _card.TransferMoney(receiverCard, amount);
            }
        }

    }
}
