using BankApp.Domain.Credits;
using BankApp.Domain.Clients;

namespace BankApp.Domain.Cards
{
    class BankVipServicesFactory : BankServicesFactory
    {
        public BankVipServicesFactory(Client client):base(client) { }
        public override CreditCard CreateCreditCard()
        {
            return new CreditCard(this.Client, new PlatinumTier(), 0.015m, 450, 0, 1, 10000);
        }

        public override DebitCard CreateDebitCard()
        {
            return new DebitCard(this.Client, new PlatinumTier(), 0.015m, 450, 0);
        }

        public override Credit CreateCredit()
        {
            ICreditBuilder creditBuilder = new CreditBuilder();

            var credit = creditBuilder.SetReceiver(this.Client).DetermineCreditAmount().DeterminePeriod().SetMonthlyInterest(1).Build();

            return credit;
        }
    }
}
