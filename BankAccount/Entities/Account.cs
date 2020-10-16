using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Extensions;

namespace BankAccount.Entities
{
    abstract class Account : IAccount
    {
        public double StartingBalance { get; set; }
        public double CurrentBalance { get; set; }
        double totalDeposits;
        int numDeposits;
        double totalWithdraw;
        protected int numWithdraw;
        public double InterestRate { get; set; }
        protected double monServCharge;
        protected AccountStatus AS;

        public Account (double sB, double iR)
        {
            this.StartingBalance = sB;
            this.CurrentBalance = this.StartingBalance;
            this.InterestRate = iR;
        }
        
        public virtual void MakeWithdrawl(double amount)
        {
            CurrentBalance -= amount;
            totalWithdraw += amount;
            numWithdraw++;
            Console.WriteLine("The balance is now {0}", CurrentBalance.toNAMoney(true));
        }
        
        public virtual void MakeDeposit(double amount)
        {
            CurrentBalance += amount;
            totalDeposits += amount;
            numDeposits++;
            Console.WriteLine("The balance is now {0}", CurrentBalance.toNAMoney(true));
        }

        public void CalculateInterest()
        {
            double monInterestRate = InterestRate / 12;
            double monInterest = CurrentBalance * monInterestRate;
            CurrentBalance += monInterest;
            Console.WriteLine("The balance is now {0}", CurrentBalance.toNAMoney(true));
        }

        public virtual string CloseAndReport()
        {
            CurrentBalance -= monServCharge;

            CalculateInterest();

            StringBuilder report = new StringBuilder();
            report.Append("This month's starting balance: ");
            report.Append(string.Format("{0}", StartingBalance.toNAMoney(true)) + "\n");
            report.Append("This month's final balance: ");
            report.Append(string.Format("{0}", CurrentBalance.toNAMoney(true)) + "\n");
            report.Append("This month's total withdrawls: ");
            report.Append(string.Format("{0}", totalWithdraw.toNAMoney(true)) + "\n");
            report.Append("This month's total deposits: ");
            report.Append(string.Format("{0}", totalDeposits.toNAMoney(true)) + "\n");
            report.Append("This month's total number of withdrawls: ");
            report.Append(string.Format("{0}", numWithdraw) + "\n");
            report.Append("This month's total number of deposits: ");
            report.Append(string.Format("{0}", numDeposits) + "\n");
            report.Append("The monthly interest that was calculated this month was:");
            report.Append(string.Format("{0}", (CurrentBalance*(InterestRate/12)).toNAMoney(true)));

            numWithdraw = 0;
            numDeposits = 0;
            monServCharge = 0.0;

            return report.ToString();
        }
    }
}
