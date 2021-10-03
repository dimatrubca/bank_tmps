using BankApp.Domain.Credits;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
    class BankSimpleServicesFactory : BankServicesFactory
    {

        public BankSimpleServicesFactory(Client client):base(client) { }
        public override CreditCard CreateCreditCard()
        {
            return new CreditCard(Client, CardType.Gold, 0.025m, 450, 0, 0.5m, 1000);
        }

        public override DebitCard CreateDebitCard()
        {
            return new DebitCard(this.Client, CardType.Gold, 0.025m, 450, 0);
        }

        public override Credit CreateCredit()
        {
            ICreditBuilder creditBuilder = new CreditBuilder();

            var credit = creditBuilder.SetReceiver(this.Client).DetermineCreditAmount().DeterminePeriod().DetermineGuarantor().SetMonthlyInterest(2).Build();

            return credit;
        }
    }
}
