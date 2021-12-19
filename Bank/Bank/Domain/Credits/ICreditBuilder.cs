using BankApp.Domain.Clients;

namespace BankApp.Domain.Credits
{
    interface ICreditBuilder
    {
        public ICreditBuilder SetReceiver(Client client);
        public ICreditBuilder DetermineCreditAmount();
        public ICreditBuilder DeterminePeriod();
        public ICreditBuilder DetermineGuarantor();
        public ICreditBuilder SetMonthlyInterest(decimal amount);
        public Credit Build();
    }
}
