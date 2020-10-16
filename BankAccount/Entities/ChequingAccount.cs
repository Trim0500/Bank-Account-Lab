using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Extensions;

namespace BankAccount.Entities
{
    class ChequingAccount : Account
    {
        public ChequingAccount (double sB, double iR) : base(sB, iR)
        {
        }

        public override void MakeWithdrawl(double amount)
        {
            if (base.CurrentBalance - amount < 0)
            {
                Console.WriteLine("Writing a cheque of {0} will cause the balance to dip past $0, service charges of $15 will be applied.", amount.toNAMoney(true));
                base.CurrentBalance -= 15.0;
                if (base.CurrentBalance < 0)
                {
                    Console.WriteLine("This account now owes money to the bank.");
                }

                base.MakeWithdrawl(amount);
            }
            else
                base.MakeWithdrawl(amount);
        }

        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount);
        }

        public override string CloseAndReport()
        {
            base.monServCharge += 5;

            for (int i = 0; i <= base.numWithdraw; i++)
            {
                base.monServCharge += .10;
            }

            return base.CloseAndReport();
        }
    }
}
