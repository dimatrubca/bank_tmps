using BankApp.Domain.Clients;


namespace BankApp.Domain.Cards
{
     class CreditCard : Card
     {
          public CreditCard(Client owner, Tier tier, 
               decimal transactionFee, decimal annualFee, decimal balance,
               decimal bonusPoints, decimal spendingLimit) : base(owner, tier, transactionFee, annualFee, balance)
          {
               BonusPoints = bonusPoints;
               SpendingLimit = spendingLimit;
          }

          public decimal BonusPoints { get; set; }
          public decimal SpendingLimit { get; set; }

          public override decimal SpendingBalance() {
               return Balance + SpendingLimit;
          }
     }
}
