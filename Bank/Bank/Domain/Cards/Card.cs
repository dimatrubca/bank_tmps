namespace BankApp.Domain.Cards
{
    abstract class Card
    {
        protected Card(Client owner, CardType type, decimal transactionFee, decimal annualFee, decimal balance)
        {
            Issuer = Bank.Instance;
            Owner = owner;
            Type = type;
            TransactionFee = transactionFee;
            AnnualFee = annualFee;
            Balance = balance;
        }

        public Bank Issuer { get; set; }
        public Client Owner { get; set; }
        public CardType Type { get; set; }
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
