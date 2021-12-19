using BankApp.Domain.Clients;

namespace BankApp.Domain.Cards
{
    abstract class Card : ICard
    {
        protected Card(Client owner, Tier tier, decimal transactionFee, decimal annualFee, decimal balance) 
        {
            Issuer = Bank.Instance;
            Owner = owner;
            Tier = tier;
            TransactionFee = transactionFee;
            AnnualFee = annualFee;
            Balance = balance;
            clientNotificationStrategy = new EmailClientNotification();
        }

        public Bank Issuer { get; set; }
        public Client Owner { get; set; }
        public Tier Tier { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal AnnualFee { get; set; }
        public decimal Balance { get; set; }

        public abstract decimal SpendingBalance();

        public ClientNotificationStrategy clientNotificationStrategy;


        public void TransferMoney(Card card, decimal amount)
        {
            Issuer.ExecuteCardTransfer(this, card, amount);
            clientNotificationStrategy.NotifyPayment(Owner, card.Owner, amount);
        }

        public void SetClientNotificationStrategy(ClientNotificationStrategy strategy)
        {
            this.clientNotificationStrategy = strategy;
        }

    }
}
