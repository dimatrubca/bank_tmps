using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
    class PlatinumTier : Tier
    {
        public PlatinumTier() : base(0.3m)
        { }
        public override string ToString()
        {
            return "Gold";
        }
    }
}
