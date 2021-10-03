using BankApp.Domain.BankAccounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain
{
    class Client
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CashAmount { get; set; }
        public bool IsVip { get; set; }
        public List<BankAccountContract> Documents { get; set; }

        public override string ToString()
        {
            return "===========\n" +
                   $"Id: {Id}" +
                   $"\nFirst Name: {FirstName}" +
                   $"\nLast Name: {LastName}" +
                   $"\nCash Amount: {CashAmount}" +
                   $"\nIs Vip: {IsVip}\n" +
                   "=============\n";
        }
    }
}
