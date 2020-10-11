using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Entities
{
    class SavingsAccount : Account
    {
        public SavingsAccount (double sB, double iR) : base(sB, iR)
        {
            if (sB >= 25)
            {
                base.AS = AccountStatus.Active;
            }
            else
                base.AS = AccountStatus.Inactive;
        }

        public override void MakeWithdrawl(double amount)
        {
            if(base.AS == AccountStatus.Inactive)
            {
                Console.WriteLine("Apologies, the account is inactive, therefore the withdrawl may not be done");
            }
            else
            {
                base.MakeWithdrawl(amount);
                if (base.CurrentBalance < 25)
                {
                    Console.WriteLine("The current balance is now {0:C2} and has now become inactive.");
                    Console.WriteLine("No more withdrawls may be done until the balance exceeds 25$.");
                }
            }
        }
        public override void MakeDeposit(double amount)
        {
            if (base.AS == AccountStatus.Inactive)
            {
                Console.WriteLine("This account inactive right now and must have a balance greater than or equal to 25$ to become active again.");
                base.MakeDeposit(amount);
                if (base.CurrentBalance >= 25)
                    Console.WriteLine("The new balance is {0:C2} and is now active again!", CurrentBalance);
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
                Console.WriteLine("This account withdrew 4 or more times, a 1$ service charge will apply to each withdrawl after the third one.");
                for (int i = 4; i <= base.numWithdraw; i++)
                {
                    base.monServCharge++;
                }
            }
            
            return base.CloseAndReport();
        }
    }
}
