using System;

namespace BankApp.Domain.Credits
{
    class Credit
    {
        public decimal Amount { get; set; }
        public string ReceiverId { get; set; }  //TODO: chenge to receiverId
        public DateTime Timestamp { get; set; }
        public int Duration { get; set; }
        public decimal MonthlyInterest { get; set; } // or loan rate
        public string GuarantorId { get; set; }

        public override string ToString()
        {
            return "\n============\n" +
                $"Credit amount: {Amount}" +
                $"\nReceiver: {ReceiverId}" +
                $"\nDuration: {Duration}" +
                $"\nMonthly Interest: {MonthlyInterest}" +
                $"\nGuarantorId: {GuarantorId}" +
                "\n============\n";
        }
    }
}
