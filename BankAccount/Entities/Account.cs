using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Entities
{
    abstract class Account : IAccount
    {
        public double startingBalance { get; set; }
        public double currentBalance { get; set; }
        double totalDeposits;
        int numDeposits;
        double totalWithdraw;
        int numWithdraw;
        public double interestRate { get; set; }
        double monServCharge;
        AccountStatus AS = AccountStatus.Active;

        Account (double sB, double iR)
        {
            this.startingBalance = sB;
            this.interestRate = iR;
        }
        
        public override void MakeWithdrawl(double amount)
        {
            currentBalance -= amount;
            numWithdraw++;
        }
        
        public override void MakeDeposit(double amount)
        {
            currentBalance += amount;
            numDeposits++;
        }

        public override void CalculateInterest()
        {
            double monInterestRate = interestRate / 12;
            double monInterest = currentBalance * monInterestRate;
            currentBalance += monInterest;
        }

        public override string CloseAndReport()
        {
            currentBalance -= monServCharge;

            CalculateInterest();

            numWithdraw = 0;
            numDeposits = 0;
            monServCharge = 0.0;

            StringBuilder report = new StringBuilder();
            report.Append("This month's starting balance: ");
            report.Append(string.Format("{0:C2}", startingBalance) + "\n");
            report.Append("This month's final balance: ");
            report.Append(string.Format("{0:C2}", currentBalance) + "\n");
            report.Append("The values yield a change of: ");
            report.Append(string.Format("{0:F2}", (currentBalance/startingBalance)*100));

            return report.ToString();
        }
    }
}
