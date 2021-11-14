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

        public Client RegisterClient(string firstName, string lastName, string id, int cashAmount)
        {
            var client = new Client
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                CashAmount = cashAmount
            };

            // todo: persist client

            return client;
        }
        public Client AuthenticateClient(string clientId)
        {
            foreach (var currClient in clients)
            {
                if (currClient.Id == clientId)
                {
                    return currClient;
                }
            }

            return null;
        }


        public void RegisterCard(Card card)
        {
            this.issuedCards.Add(card);
        }


        public Credit TakeLoan(BankServicesFactory bankServicesFactory)
        {
            Credit credit = bankServicesFactory.CreateCredit();

            return credit;
        }
    }
}
