using BankApp.Data;
using BankApp.Domain.Cards;
using BankApp.Domain.Credits;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BankApp.Domain
{
    class Bank
    {

        private static readonly Bank instance;
        static Bank() { 
            instance = new Bank();

            instance.clients = DataReader.ReadClients();
        }

        public static Bank Instance
        {
            get
            {
                return instance;
            }
        }

        public List<Client> clients;
        public List<Card> issuedCards = new List<Card>();

        private Bank() { }
        public void ExecuteCardTransfer(Card senderCard, Card receiverCard, decimal amount)
        {
            if (senderCard.SpendingBalance() < amount)
            {
                throw new InsufficientFundsException(senderCard.SpendingBalance(), amount);
            }

            senderCard.Balance -= amount;
            receiverCard.Balance += amount;
        }

        public BankServicesFactory AuthenticateClient()
        {

            Console.WriteLine("Please, enter your ID");
            string input = Console.ReadLine();

            Client client = null;
            foreach (var currClient in clients)
            {
                if (currClient.Id == input)
                {
                    Console.WriteLine($"User found. Details:\n");
                    Console.WriteLine(currClient);

                    client = currClient;
                    break;
                }
            }

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

                client = new Client
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    CashAmount = cashAmount
                };
            }

            BankServicesFactory bankServicesFactory;

            if (client.IsVip) bankServicesFactory = new BankVipServicesFactory(client);
            else bankServicesFactory = new BankSimpleServicesFactory(client);

            return bankServicesFactory;
        }

        public void Open()
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
                        BankServicesFactory bankServicesFactory = this.AuthenticateClient();
                        this.AuthenticatedLoop(bankServicesFactory);
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }

            }
        }


        public void IssueCard(BankServicesFactory bankServicesFactory) {

            while (true)
            {
                Console.WriteLine("Please, select an operation: ");
                Console.WriteLine("1. Get credit card");
                Console.WriteLine("2. Get debit card");
                Console.WriteLine("3. Return to previous step");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        var debitCard = bankServicesFactory.CreateDebitCard();
                        this.issuedCards.Add(debitCard);
                        Console.WriteLine($"{debitCard.Type} debit card was successfully issued to client with id {debitCard.Owner.Id}\n");
                        break;
                    case "2":
                        var creditCard = bankServicesFactory.CreateCreditCard();
                        this.issuedCards.Add(creditCard);
                        Console.Write($"{creditCard.Type} credit card was successfully issued to client with id {creditCard.Owner.Id}\n");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }
            }


        }

        public Credit TakeLoan(BankServicesFactory bankServicesFactory)
        {
            Credit credit = bankServicesFactory.CreateCredit();

            return credit;
        }


        public void AuthenticatedLoop(BankServicesFactory bankServicesFactory)
        {
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
                        this.IssueCard(bankServicesFactory);
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
    }
}
