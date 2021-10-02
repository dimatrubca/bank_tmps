using Bank.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain
{
    class Bank
    {

        private static readonly Bank instance = new Bank();
        static Bank() { }

        public static Bank Instance
        {
            get
            {
                return instance;
            }
        }

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

        public Client AuthenticateClient()
        {

            Console.WriteLine("Please, enter your ID");

            // todo: read existing users, create new if not exists
            Console.WriteLine("Welcome to our bank!\nPlease, enter your full name: ");

            Client client = new Client
            {
                Id = "auto-generated-id",
                FirstName = "Dima",
                LastName = "Trubca",
                CashAmount = 1500
            };

            return client;
        }

        public void Open()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the ImperioBank");
                Console.WriteLine("===========================");
                Console.WriteLine("Please, select an operation (enter a number):");
                Console.WriteLine("1. Pass Authentication");
                Console.WriteLine("4. Exit");
                Console.WriteLine();

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                }

            }
        }

        public void AuthenticatedLoop()
        {
            while (true)
            {
                Console.WriteLine("Please, selected an operation: ");
                Console.WriteLine("Open Bank Account");
                Console.WriteLine("1 - Get Card");
                Console.WriteLine("2 - Exchange money");
                Console.WriteLine("3 - Take a loan");
            }
        }
    }
}
