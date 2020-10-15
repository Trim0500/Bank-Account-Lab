using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Entities;

namespace BankAccount.Extensions
{
    static class AccountExtension
    {
        public static double GetPercentageChange(this Account a)
        {
            return (a.StartingBalance / a.CurrentBalance) * 100;
        }
    }
}
