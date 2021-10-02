using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain
{
     interface IPrototype
     {
          public IPrototype Clone();
     }
}
