using System;


namespace BankApp.Domain
{
    interface IPrototype
    {
        public IPrototype Clone();
    }
}
