using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Entities
{
    interface IExchangable
    {
        double USValue(double rate);
    }
}
