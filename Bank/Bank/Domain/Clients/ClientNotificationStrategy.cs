using BankApp.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Clients
{
    abstract class ClientNotificationStrategy
    {
        public abstract void NotifyPayment(Client sender, Client receiver, decimal amount);
    }
}
