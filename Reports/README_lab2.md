# TMPS. Laboratory work number 2. 
### Topic: Structural Design Patterns.
### Author: Trubca Dmitri
### Domain: Bank 
## Theory
Structural patterns explain how to assemble objects and classes into larger structures while keeping these structures flexible and efficient.<br/>
Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors. Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object. A proxy controls access to the original object, allowing you to perform something either before or after the request gets through to the original object. Facade is a structural design pattern that provides a simplified interface to a library, a framework, or any other complex set of classes.

## Implementation
In this project 3 different structural design patterns were implemented: Proxy, Facade and decorator<br/>
The protected proxy pattern was chosen in order to allow performing safe transfer operations between cards. The CardGuardProxy should ensure the receiver of the money is not inside the blacklist for a successful transfer.
and it has to be accessed oftenly from other classes.<br/>

**`CardGuardProxy.cs`**
```
    class CardGuardProxy : ICard
    {
        private static List<string> blackList;
        private ICard _card;

        static CardGuardProxy()
        {
            blackList = new List<string> { "1232323567", "12345123" };
        }

        public CardGuardProxy(ICard card)
        {
            _card = card;
        }

        public void TransferMoney(Card receiverCard, decimal amount)
        {
            if (!blackList.Contains(receiverCard.Owner.Id))
            {
                _card.TransferMoney(receiverCard, amount);
            }
        }

    }
```

BankManager class was implemented using **Facade Pattern**. It provides a simple interface to a complex subsystem for bank management, such as Open (bank), Authenticate Client or Issue Card.
<br/>
```
    class BankManager
    {
        public void Open(Bank bank)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the ImperioBank");
                Console.WriteLine("===========================");
                Console.WriteLine("Please, select an operation (enter a number):");
                Console.WriteLine("1. Pass Authentication");
                Console.WriteLine("2. Exit");
                Console.WriteLine();

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Client client = this.AuthenticateClient(bank);

                        this.AuthenticatedLoop(client, bank);
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }

            }
        }

        public Client AuthenticateClient(Bank bank)
        {
            Console.WriteLine("Please, enter your ID");
            string input = Console.ReadLine();

            Client client = bank.AuthenticateClient(input);

            if (client == null)
            {
                Console.WriteLine("Welcome to our bank!\nPlease, enter your first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your ID: ");
                string id = Console.ReadLine();
                Console.WriteLine("How much cash do you have?");
                int cashAmount = 0;
                Int32.TryParse(Console.ReadLine(), out cashAmount);

                client = bank.RegisterClient(firstName, lastName, id, cashAmount);
            }

            return client;
        }
        public void AuthenticatedLoop(Client client, Bank bank)
        {
            BankServicesFactory bankServicesFactory;

            if (client.IsVip) bankServicesFactory = new BankVipServicesFactory(client);
            else bankServicesFactory = new BankSimpleServicesFactory(client);

            while (true)
            {
                Console.WriteLine("Please, selected an operation: ");
                Console.WriteLine("Open Bank Account");
                Console.WriteLine("1 - Get Card");
                Console.WriteLine("2 - Take a loan");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        this.IssueCard(bankServicesFactory, bank);
                        break;
                    case "2":
                        Credit credit = bankServicesFactory.CreateCredit();
                        Console.WriteLine($"Credit issued successfully");
                        Console.WriteLine("Details: ");
                        Console.WriteLine(credit);

                        break;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }
            }
        }

        public void IssueCard(BankServicesFactory bankServicesFactory, Bank bank)
        {

            while (true)
            {
                Console.WriteLine("Please, select an operation: ");
                Console.WriteLine("1. Get credit card");
                Console.WriteLine("2. Get debit card");
                Console.WriteLine("3. Return to previous step");

                string userChoice = Console.ReadLine();

                Card card = null;

                switch (userChoice)
                {
                    case "1":
                        card = bankServicesFactory.CreateDebitCard();
                        Console.WriteLine($"{card.Tier} debit card was successfully issued to client with id {card.Owner.Id}\n");
                        break;
                    case "2":
                        card = bankServicesFactory.CreateCreditCard();
                        Console.Write($"{card.Tier} credit card was successfully issued to client with id {card.Owner.Id}\n");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option selected, try again...");
                        break;
                }
                
                if (card != null)
                {
                    bank.RegisterCard(card);
                }
            }


        }
    }
```
The **decorator** pattern is used to add additional behaviour for bank cards during runtime. Now, it's possible to use the cashback features (for a card you can register multiple cashback operators (through decorator), which track all of the money transfers and return a part of the purchase to the owner.

**`BankSimpleServicesFactory.cs`**
```
    class CardCashBackDecorator : ICard
    {
        private ICard _card;
        public decimal Balance { get =>  _card.Balance; set => _card.Balance = value; }
        public decimal CashbackPct { get; set; }
        public string OrgName;


        public CardCashBackDecorator(ICard card, decimal cashbackPct, string orgName)
        {
            _card = card;
            CashbackPct = cashbackPct;
            OrgName = orgName;
        }

        public void TransferMoney(Card receiverCard, decimal amount)
        {
            _card.TransferMoney(receiverCard, amount);

            decimal bonus = amount * CashbackPct;
            _card.Balance += bonus;
        }
    }
```
<br>
