using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
    class CardCashBackDecorator : ICard
    {
        private ICard _card;
        public decimal Balance { get =>  _card.Balance; set => _card.Balance = value; }
        public decimal CashbackPct { get; set; }
        public string OrgName;


        public CardCashBackDecorator(ICard card, decimal cashbackPct, string orgName)
        {
            _card = card;
            CashbackPct = cashbackPct;
            OrgName = orgName;
        }

        public void TransferMoney(Card receiverCard, decimal amount)
        {
            _card.TransferMoney(receiverCard, amount);

            decimal bonus = amount * CashbackPct;
            _card.Balance += bonus;
        }
    }
}
