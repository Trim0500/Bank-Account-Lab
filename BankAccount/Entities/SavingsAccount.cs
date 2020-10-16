using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Extensions;

namespace BankAccount.Entities
{
    class SavingsAccount : Account
    {
        public SavingsAccount (double sB, double iR) : base(sB, iR)
        {
        }

        public override void MakeWithdrawl(double amount)
        {
            base.AS = AccountStatus.Inactive;

            if (base.CurrentBalance >= 25)
                base.AS = AccountStatus.Active;

            if (base.AS == AccountStatus.Inactive)
            {
                Console.WriteLine("Apologies, the account is inactive, therefore the withdrawl may not be done");
            }
            else
            {
                base.MakeWithdrawl(amount);
                if (base.CurrentBalance < 25)
                {
                    Console.WriteLine("The current balance is now {0} and has now become inactive.", CurrentBalance.toNAMoney(true));
                    Console.WriteLine("No more withdrawls may be done until the balance exceeds 25$.");
                }
            }
        }
        public override void MakeDeposit(double amount)
        {
            base.AS = AccountStatus.Inactive;

            if (base.CurrentBalance >= 25)
                base.AS = AccountStatus.Active;

            if (base.AS == AccountStatus.Inactive)
            {
                Console.WriteLine("This account is inactive right now and must have a balance greater than or equal to 25$ to become active again.");
                base.MakeDeposit(amount);
                if (base.CurrentBalance >= 25)
                    Console.WriteLine("The new balance is {0} and is now active again!", CurrentBalance.toNAMoney(true));
            }
            else
            {
                base.MakeDeposit(amount);
            }
        }

        public override string CloseAndReport()
        {
            if (base.numWithdraw >= 4)
            {
                Console.WriteLine("This account withdrew 4 or more times, a 1$ service charge will apply to each withdrawl after the forth one.");
                for (int i = 5; i <= base.numWithdraw; i++)
                {
                    base.monServCharge++;
                }
            }
            
            return base.CloseAndReport();
        }
    }
}
