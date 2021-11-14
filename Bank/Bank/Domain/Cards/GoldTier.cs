using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain.Cards
{
    class GoldTier : Tier
    {
        public GoldTier() : base(0.2m)
        {
        }

        public override string ToString()
        {
            return "Gold";
        }
    }
}
