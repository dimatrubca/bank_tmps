using BankApp.Domain.Cards;
using BankApp.Domain.Credits;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain
{
    class BankManager
    {
        public void Open(Bank bank)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the ImperioBank");
                Console.WriteLine("===========================");
                Console.WriteLine("Please, select an operation (enter a number):");
                Console.WriteLine("1. Pass Authentication");
                Console.WriteLine("2. Exit");
                Console.WriteLine();

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Client client = this.AuthenticateClient(bank);

                        this.AuthenticatedLoop(client, bank);
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }

            }
        }

        public Client AuthenticateClient(Bank bank)
        {
            Console.WriteLine("Please, enter your ID");
            string input = Console.ReadLine();

            Client client = bank.AuthenticateClient(input);

            if (client == null)
            {
                Console.WriteLine("Welcome to our bank!\nPlease, enter your first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your ID: ");
                string id = Console.ReadLine();
                Console.WriteLine("How much cash do you have?");
                int cashAmount = 0;
                Int32.TryParse(Console.ReadLine(), out cashAmount);

                client = bank.RegisterClient(firstName, lastName, id, cashAmount);
            }

            return client;
        }
        public void AuthenticatedLoop(Client client, Bank bank)
        {
            BankServicesFactory bankServicesFactory;

            if (client.IsVip) bankServicesFactory = new BankVipServicesFactory(client);
            else bankServicesFactory = new BankSimpleServicesFactory(client);

            while (true)
            {
                Console.WriteLine("Please, selected an operation: ");
                Console.WriteLine("Open Bank Account");
                Console.WriteLine("1 - Get Card");
                Console.WriteLine("2 - Take a loan");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        this.IssueCard(bankServicesFactory, bank);
                        break;
                    case "2":
                        Credit credit = bankServicesFactory.CreateCredit();
                        Console.WriteLine($"Credit issued successfully");
                        Console.WriteLine("Details: ");
                        Console.WriteLine(credit);

                        break;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }
            }
        }

        public void IssueCard(BankServicesFactory bankServicesFactory, Bank bank)
        {

            while (true)
            {
                Console.WriteLine("Please, select an operation: ");
                Console.WriteLine("1. Get credit card");
                Console.WriteLine("2. Get debit card");
                Console.WriteLine("3. Return to previous step");

                string userChoice = Console.ReadLine();

                Card card = null;

                switch (userChoice)
                {
                    case "1":
                        card = bankServicesFactory.CreateDebitCard();
                        Console.WriteLine($"{card.Tier} debit card was successfully issued to client with id {card.Owner.Id}\n");
                        break;
                    case "2":
                        card = bankServicesFactory.CreateCreditCard();
                        Console.Write($"{card.Tier} credit card was successfully issued to client with id {card.Owner.Id}\n");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }
                
                if (card != null)
                {
                    bank.RegisterCard(card);
                }
            }


        }
    }
}
