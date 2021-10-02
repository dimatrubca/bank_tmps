using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Cards
{
     abstract class Card
     {
          protected Card(Bank issuer, Client owner, CardType type, decimal transactionFee, decimal annualFee, decimal balance)
          {
               Issuer = issuer;
               Owner = owner;
               Type = type;
               TransactionFee = transactionFee;
               AnnualFee = annualFee;
               Balance = balance;
          }

          public Bank Issuer { get; set; } 
          public Client Owner { get; set; }
          public CardType Type { get; set; }
          public decimal TransactionFee { get; set; }
          public decimal AnnualFee { get; set; }
          public decimal Balance { get; set; }

          public abstract decimal SpendingBalance();

          public void TransferMoney(Card card, decimal amount) {
               Issuer.ExecuteCardTransfer(this, card, amount);
          }

     }
}
