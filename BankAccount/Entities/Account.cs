using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.InterestRate = iR;
        }
        
        public virtual void MakeWithdrawl(double amount)
        {
            CurrentBalance -= amount;
            numWithdraw++;
        }
        
        public virtual void MakeDeposit(double amount)
        {
            CurrentBalance += amount;
            numDeposits++;
        }

        public void CalculateInterest()
        {
            double monInterestRate = InterestRate / 12;
            double monInterest = CurrentBalance * monInterestRate;
            CurrentBalance += monInterest;
        }

        public virtual string CloseAndReport()
        {
            CurrentBalance -= monServCharge;

            CalculateInterest();

            numWithdraw = 0;
            numDeposits = 0;
            monServCharge = 0.0;

            StringBuilder report = new StringBuilder();
            report.Append("This month's starting balance: ");
            report.Append(string.Format("{0:C2}", StartingBalance) + "\n");
            report.Append("This month's final balance: ");
            report.Append(string.Format("{0:C2}", CurrentBalance) + "\n");
            report.Append("The values yield a change of: ");
            report.Append(string.Format("{0:F2}", (CurrentBalance/StartingBalance)*100));

            return report.ToString();
        }
    }
}
