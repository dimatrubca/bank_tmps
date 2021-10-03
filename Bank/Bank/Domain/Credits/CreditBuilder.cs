using System;

namespace BankApp.Domain.Credits
{
    class CreditBuilder : ICreditBuilder
    {
        private readonly Credit _credit;

        public CreditBuilder()
        {
            _credit = new Credit();
        }

        public ICreditBuilder SetReceiver(Client client)
        {
            _credit.ReceiverId = client.Id;

            return this;
        }

        public ICreditBuilder DetermineCreditAmount()
        {
            Console.WriteLine("Enter the loan amount: ");
            string userInput = Console.ReadLine();
            decimal amount = Convert.ToDecimal(userInput);

            _credit.Amount = amount;

            return this;
        }

        public ICreditBuilder DeterminePeriod()
        {
            Console.WriteLine("Enter loan period (in months)");
            string userInput = Console.ReadLine();
            int amount = Convert.ToInt32(userInput);

            _credit.Duration = amount;

            return this;
        }

        public ICreditBuilder SetMonthlyInterest(decimal monthlyInterest)
        {
            _credit.MonthlyInterest = monthlyInterest;

            return this;
        }

        public ICreditBuilder DetermineGuarantor()
        {
            Console.WriteLine("Enter the id of the guarantor:");

            string userInput = Console.ReadLine();
            //TODO: check if client with such id exiss
            _credit.GuarantorId = userInput;
            return this;
        }

        public Credit Build()
        {
            return _credit;
        }
    }
}
