using BankApp.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Clients
{
    class SMSClientNotification : ClientNotificationStrategy
    {
        public override void NotifyPayment(Client sender, Client receiver, decimal amount)
        {
            Console.WriteLine($"Sending sms to {sender.Phone}. Message: Transfer of {amount}$ to " +
                 $"{receiver.FirstName} {receiver.LastName} successfully executed");
        }
    }
}
