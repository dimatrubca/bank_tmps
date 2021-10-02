using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Credits
{
     class Credit
     {
          public decimal Amount { get; set; }
          public Client Receiver { get; set; }  //TODO: chenge to receiverId
          public DateTime Timestamp { get; set; }
          public int Duration { get; set; }
          public decimal MonthlyInterest { get; set; } // or loan rate
          public string GuarantorId { get; set; }
     }
}
