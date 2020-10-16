using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BankAccount.Entities;
using BankAccount.Extensions;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account A1 = new SavingsAccount(5.00, .02);
            Account A2 = new ChequingAccount(5.00, .02);
            GlobalSavingsAccount A3 = new GlobalSavingsAccount(5.00, .02);

            string option;
            
            Console.WriteLine("You booted up the Personal Bank App!");
            do
            {
                Console.WriteLine("You accessed the General page:");

                Console.WriteLine(String.Format("A. Savings\nB. Checking\nC. Global Savings\nQ. Exit"));
                option = Console.ReadLine().ToUpper();

                switch(option)
                {
                    case "A":
                        MenuS(A1);
                        break;
                    case "B":
                        MenuC(A2);
                        break;
                    case "C":
                        MenuGS(A3);
                        break;
                    case "Q":
                        Environment.Exit(0);
                        break;
                    default:
                        throw new InvalidOperationException("That's not what I'm looking for...");
                }
            }
            while(option != "Q");
        }

        public static void MenuS(Account SA)
        {
            string optionS;

            Regex Rgx = new Regex(@"\d+\.\d+");

            do
            {
                Console.WriteLine("You accessed the Savings page:");

                Console.WriteLine(String.Format("A. Deposit\nB. Withdraw\nC. Close + Report\nR. Go Back"));
                optionS = Console.ReadLine().ToUpper();

                switch(optionS)
                {
                    case "A":
                        Console.WriteLine("Enter the amount you want to deposit:");
                        string stringAmountD = Console.ReadLine();
                        if (!(Rgx.IsMatch(stringAmountD)))
                            throw new FormatException("The number you entered is not acceptable");
                        double.TryParse(stringAmountD, out double userAmountD);
                        SA.MakeDeposit(userAmountD);
                        break;
                    case "B":
                        Console.WriteLine("Enter the amount you want to withdraw:");
                        string stringAmountW = Console.ReadLine();
                        if (!(Rgx.IsMatch(stringAmountW)))
                            throw new FormatException("The number you entered is not acceptable");
                        double.TryParse(stringAmountW, out double userAmountW);
                        SA.MakeWithdrawl(userAmountW);
                        break;
                    case "C":
                        Console.WriteLine(SA.CloseAndReport());
                        Console.WriteLine("The values yield a change of: {0:F2}%", SA.GetPercentageChange());
                        break;
                    case "R":
                        break;
                    default:
                        throw new InvalidOperationException("That's not what I'm looking for...");
                }
            }
            while (optionS != "R");
        }

        public static void MenuC(Account CA)
        {
            string optionC;

            Regex Rgx = new Regex(@"\d+\.\d+");

            do
            {
                Console.WriteLine("You accessed the Chequing page:");
                
                Console.WriteLine(String.Format("A. Deposit\nB. Withdraw\nC. Close + Report\nR. Go Back"));
                optionC = Console.ReadLine().ToUpper();

                switch (optionC)
                {
                    case "A":
                        Console.WriteLine("Enter the amount you want to deposit:");
                        string stringAmountD = Console.ReadLine();
                        if (!(Rgx.IsMatch(stringAmountD)))
                            throw new FormatException("The number you entered is not acceptable");
                        double.TryParse(stringAmountD, out double userAmountD);
                        CA.MakeDeposit(userAmountD);
                        break;
                    case "B":
                        Console.WriteLine("Enter the amount you want to withdraw:");
                        string stringAmountW = Console.ReadLine();
                        if (!(Rgx.IsMatch(stringAmountW)))
                            throw new FormatException("The number you entered is not acceptable");
                        double.TryParse(stringAmountW, out double userAmountW);
                        CA.MakeWithdrawl(userAmountW);
                        break;
                    case "C":
                        Console.WriteLine(CA.CloseAndReport());
                        Console.WriteLine("The values yield a change of: {0:F2}%", CA.GetPercentageChange());
                        break;
                    case "R":
                        break;
                    default:
                        throw new InvalidOperationException("That's not what I'm looking for...");
                }
            }
            while (optionC != "R");
        }

        public static void MenuGS(GlobalSavingsAccount AGS)
        {
            string optionGS;

            Regex Rgx = new Regex(@"\d+\.\d+");

            do
            {
                Console.WriteLine("You accessed the Global Savings page:");

                Console.WriteLine(String.Format("A. Deposit\nB. Withdraw\nC. Close + Report\nD. Report Balance in USD\nR. Go Back"));
                optionGS = Console.ReadLine().ToUpper();

                switch (optionGS)
                {
                    case "A":
                        Console.WriteLine("Enter the amount you want to deposit:");
                        string stringAmountD = Console.ReadLine();
                        if (!(Rgx.IsMatch(stringAmountD)))
                            throw new FormatException("The number you entered is not acceptable");
                        double.TryParse(stringAmountD, out double userAmountD);
                        AGS.MakeDeposit(userAmountD);
                        break;
                    case "B":
                        Console.WriteLine("Enter the amount you want to withdraw:");
                        string stringAmountW = Console.ReadLine();
                        if (!(Rgx.IsMatch(stringAmountW)))
                            throw new FormatException("The number you entered is not acceptable");
                        double.TryParse(stringAmountW, out double userAmountW);
                        AGS.MakeWithdrawl(userAmountW);
                        break;
                    case "C":
                        Console.WriteLine(AGS.CloseAndReport());
                        Console.WriteLine("The values yield a change of: {0:F2}%", AGS.GetPercentageChange());
                        break;
                    case "D":
                        Console.WriteLine(AGS.USValue(0.76).toNAMoney(true));
                        break;
                    case "R":
                        break;
                    default:
                        throw new InvalidOperationException("That's not what I'm looking for...");
                }
            }
            while (optionGS != "R");
        }
    }
}
