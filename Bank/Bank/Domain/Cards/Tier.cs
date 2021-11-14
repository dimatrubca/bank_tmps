using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
    abstract class Tier
    {
        public decimal Bonus { get; set; }

        public Tier(decimal bonus)
        {
            Bonus = bonus;
        }
    }
}
