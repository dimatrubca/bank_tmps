using BankApp.Domain;
using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankManager bankManager = new BankManager();
            bankManager.Open(Bank.Instance);
          }
    }
}
