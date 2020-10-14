using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Entities
{
    class GlobalSavingsAccount : SavingsAccount, IExchangable
    {
        public GlobalSavingsAccount (double sB, double iR) : base (sB, iR)
        {
        }

        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount);
        }

        public override void MakeWithdrawl(double amount)
        {
            base.MakeWithdrawl(amount);
        }

        public override string CloseAndReport()
        {
            return base.CloseAndReport();
        }

        public virtual double USValue(double rate)
        {
            double USBalance = base.CurrentBalance * rate;
            return USBalance;
        }
    }
}
