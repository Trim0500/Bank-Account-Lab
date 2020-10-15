using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Extensions
{
    static class DoubleExtension
    {
        public static string toNAMoney(this double value, bool round)
        {
            if(round == true)
            {
                Math.Round(value);
            }
            else
            {
                Math.Round(value, MidpointRounding.ToEven);
            }

            string format;

            if (value > 0)
            {
                format = String.Format("${0:C2}", value);
            }
            else
                format = String.Format("(${0:C2})", value);

            return format;
        }
    }
}
