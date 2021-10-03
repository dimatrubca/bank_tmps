using BankApp.Domain.Credits;

namespace BankApp.Domain.Cards
{
    abstract class BankServicesFactory
    {
        public BankServicesFactory(Client client)
        {
            Client = client;
        }
        public abstract CreditCard CreateCreditCard();
        public abstract DebitCard CreateDebitCard();
        public abstract Credit CreateCredit();

        public Client Client { get; set; }

     }
}
