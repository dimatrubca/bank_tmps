# TMPS. Laboratory work number 3. 
### Topic: Behavioural Design Patterns.
### Author: Trubca Dmitri
### Domain: Bank 
## Theory
Behavioral design patterns are design patterns that identify common communication patterns between objects and realize these patterns. By doing so, these patterns increase flexibility in carrying out this communication.</br>
Strategy is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.


## Implementation
In this project, strategy design pattern was implemented<br/>
The strategy pattern is used to define multiple ways of sending notifications to clients after a card transfer, and allowing changing this behaviour at runtime.

Abstract Class representing the interface of the strategy:

**`Domain/Clients/ClientNotificationStrategy.cs`**
```
    abstract class ClientNotificationStrategy
    {
        public abstract void NotifyPayment(Client sender, Client receiver, decimal amount);
    }
```

2 Concrete Strategy implementations were defined: EmailCliantNotification and SMSClientNotification.

**`Domain/Clients/EmailClientNotification.cs`**
```
    class EmailClientNotification : ClientNotificationStrategy
    {
        public override void NotifyPayment(Client sender, Client receiver, decimal amount)
        {
            Console.WriteLine($"Sending email to {sender.Email}. Message: Transfer of {amount}$ to " +
               $"{receiver.FirstName} {receiver.LastName} successfully executed");
        }
    }
}
```

**`Domain/Clients/SMSClientNotification.cs`**
```
    class SMSClientNotification : ClientNotificationStrategy
    {
        public override void NotifyPayment(Client sender, Client receiver, decimal amount)
        {
            Console.WriteLine($"Sending sms to {sender.Phone}. Message: Transfer of {amount}$ to " +
                 $"{receiver.FirstName} {receiver.LastName} successfully executed");
        }
    }
```

Inside the *Card* class, the strategy is invoked after executing card transfer. The used strategy can be modified by calling the method *SetClientNotificationStrategy*. If not set explicitly, by default *EmailClientNotification* is being used.

```
    abstract class Card : ICard
    {
        protected Card(Client owner, Tier tier, decimal transactionFee, decimal annualFee, decimal balance) 
        {
            ...
            clientNotificationStrategy = new EmailClientNotification();
        }

        ...
        public ClientNotificationStrategy clientNotificationStrategy;


        public void TransferMoney(Card card, decimal amount)
        {
            Issuer.ExecuteCardTransfer(this, card, amount);
            clientNotificationStrategy.NotifyPayment(Owner, card.Owner, amount);
        }

        public void SetClientNotificationStrategy(ClientNotificationStrategy strategy)
        {
            this.clientNotificationStrategy = strategy;
        }
```
