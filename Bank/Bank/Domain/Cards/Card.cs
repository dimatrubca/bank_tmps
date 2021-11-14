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
        }

        public Bank Issuer { get; set; }
        public Client Owner { get; set; }
        public Tier Tier { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal AnnualFee { get; set; }
        public decimal Balance { get; set; }

        public abstract decimal SpendingBalance();

        public void TransferMoney(Card card, decimal amount)
        {
            Issuer.ExecuteCardTransfer(this, card, amount);
        }

    }
}
