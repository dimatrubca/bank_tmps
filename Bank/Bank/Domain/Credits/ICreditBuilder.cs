using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Credits
{
     interface ICreditBuilder
     {
          public void DetermineCreditAmount();
          public void DeterminePeriod();
          public void DetermineGuarantor();
     }
}
