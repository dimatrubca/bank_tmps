using BankApp.Domain.Credits;
using BankApp.Domain.Clients;


namespace BankApp.Domain.Cards
{
    class BankSimpleServicesFactory : BankServicesFactory
    {

        public BankSimpleServicesFactory(Client client):base(client) { }
        public override CreditCard CreateCreditCard()
        {
            return new CreditCard(Client, new GoldTier(), 0.025m, 450, 0, 0.5m, 1000);
        }

        public override DebitCard CreateDebitCard()
        {
            return new DebitCard(this.Client, new GoldTier(), 0.025m, 450, 0);
        }

        public override Credit CreateCredit()
        {
            ICreditBuilder creditBuilder = new CreditBuilder();

            var credit = creditBuilder.SetReceiver(this.Client).DetermineCreditAmount().DeterminePeriod().DetermineGuarantor().SetMonthlyInterest(2).Build();

            return credit;
        }
    }
}
