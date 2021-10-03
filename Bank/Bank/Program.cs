using BankApp.Domain;
using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = Bank.Instance;
            bank.Open();


          }
    }
}
