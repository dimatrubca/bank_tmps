# TMPS. Laboratory work number 1. 
### Topic: Creational Design Patterns.
### Author: Trubca Dmitri
### Domain: Bank 
## Theory
In this project 3 different creational design patterns were implemented: Singleton, Builder and Abstract Factory.<br/>
Singleton is a creational design patterns which ensures that only one object of its kind exists and provides a single point of access to it for any other code. 

## Implementation
In this application, the instance of the
"Bank" class was chosen to be implemented as a singleton, because the application logic requires exactly one instance of this class during the entire lifetime of the application,
and it has to be accessed oftenly from other classes.<br/>
```
class Bank
{

    private static readonly Bank instance;
    static Bank() { 
        instance = new Bank();

        instance.clients = DataReader.ReadClients();
    }

    public static Bank Instance
    {
        get
        {
            return instance;
        }
    }

    public List<Client> clients;
    
    ...
}
```
As there are 2 different types of bank clients (VIP clients and simple clients), both of which have access to the same services, with the exception that VIP clients get a slighly improved version
(Platinum Credit cards for VIP clients vs Gold Credit cards for simple clients, Platinum Debit cards for VIP clients vs Gold Debit cards for simple clients,
different interest and creation requirements for credits taken by VIP vs simple users), it was chosen to use the abstract factory pattern, which would simplify producing those related objects, without specifying their concrete type, depending on the type of client.
<br/>
Abstract factory (BankServicesFactory) is represented bellow.

```
abstract class BankServicesFactory
{
    public BankServicesFactory(Client client)
    {
        Client = client;
    }
    public abstract CreditCard CreateCreditCard();
    public abstract DebitCard CreateDebitCard();
    public abstract Credit CreateCredit();  

    public Client Client { get; set; }

 }
 ```
 It's extended by the **BankSimpleServicesFactory**, which is intended to provide services for ussual users, and **BankVipClientFactory** - which creates objects intended for VIP users.
<br/>
As issuing a credit is a complex process, the steps of which can differ depending on the type of the user, it was decided to implement the creation of *Credit* objects using the **builder pattern**.
Below, is defined the interface of the CreditBuilder class.
```
interface ICreditBuilder
{
    public ICreditBuilder SetReceiver(Client client);
    public ICreditBuilder DetermineCreditAmount();
    public ICreditBuilder DeterminePeriod();
    public ICreditBuilder DetermineGuarantor();
    public ICreditBuilder SetMonthlyInterest(decimal amount);
    public Credit Build();
}
```
The builder pattern is used together with the abstract factory method.
Depending on the type of the user, the steps of constructing an instance of *Credit* class differ. (e.g. VIP users don't have to specify a guarantor, the interest rate for vip users is lower...).


**`BankSimpleServicesFactory.cs`**
```
public override Credit CreateCredit()
{
    ICreditBuilder creditBuilder = new CreditBuilder();

    var credit = creditBuilder.SetReceiver(this.Client).DetermineCreditAmount().DeterminePeriod().DetermineGuarantor().SetMonthlyInterest(2).Build();

    return credit;
}
```
<br>

**`BankVipServicesFactory.cs`**
```
        public override Credit CreateCredit()
        {
            ICreditBuilder creditBuilder = new CreditBuilder();

            var credit = creditBuilder.SetReceiver(this.Client).DetermineCreditAmount().DeterminePeriod().SetMonthlyInterest(1).Build();

            return credit;
        }
```

## Results
The resulting application is a bank simulator. For now, you can perform such basic actions as authentication, getting a credit/debit card and taking a loan. The existing users are defined inside the *Data/cliens.json* file, but new ones 
can also be created.

###  Authentication and issuing a debit card exaple
<img src="https://github.com/dimatrubca/bank_tmps/blob/master/images/intro_debit_card_flow.png" width="450" title="hover text">

### Taking a load example
<img src="https://github.com/dimatrubca/bank_tmps/blob/master/images/take_loan_flow.png" width="450" title="hover text">
