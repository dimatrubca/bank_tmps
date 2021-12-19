using BankApp.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Clients
{
    class EmailClientNotification : ClientNotificationStrategy
    {
        public override void NotifyPayment(Client sender, Client receiver, decimal amount)
        {
            Console.WriteLine($"Sending email to {sender.Email}. Message: Transfer of {amount}$ to " +
               $"{receiver.FirstName} {receiver.LastName} successfully executed");
        }
    }
}
