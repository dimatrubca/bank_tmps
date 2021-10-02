using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Credits
{
     class CreditBuilder
     {
          private readonly Credit _credit;

          public void SetReceiver(Client client) 
          {
               _credit.Receiver = client;
          }

          public void DetermineCreditAmount()
          {
               Console.WriteLine("Enter the loan amount: ");
               string userInput = Console.ReadLine();
               decimal amount = Convert.ToDecimal(userInput);

               _credit.Amount = amount;
          }

          public void DeterminePeriod()
          {
               Console.WriteLine("Enter loan period (in months)");
               string userInput = Console.ReadLine();
               int amount = Convert.ToInt32(userInput);

               _credit.Duration = amount;
          }

          public void DetermineGuarantor()
          {
               Console.WriteLine("Enter the id of the guarantor:");

               string userInput = Console.ReadLine();
               //TODO: check if client with such id exiss
               _credit.Gu
          }
     }
}
