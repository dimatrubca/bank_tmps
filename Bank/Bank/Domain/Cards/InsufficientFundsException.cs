using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
     class InsufficientFundsException : Exception
     {
          public InsufficientFundsException() 
          { 
          }

          public InsufficientFundsException(decimal balance, decimal requiredBalance) : base($"Current Balance: {balance}, Required: {requiredBalance}")
          { 
          }
     }
}
