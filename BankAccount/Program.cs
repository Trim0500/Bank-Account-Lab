using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Entities;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account A1 = new SavingsAccount(5.00, .02);
            Account A2 = new ChequingAccount(5.00, .02);
            GlobalSavingsAccount A3 = new GlobalSavingsAccount(5.00, .02);

            Console.WriteLine("You booted up the Personal Bank App!");

            Console.WriteLine(String.Format("A. Savings\nB. Checking\nC. Global Savings\nQ. Exit"));
            string option = Console.ReadLine().ToUpper();

            while (option != "Q")
            {
                switch (option)
                {
                case "A":
                    Console.WriteLine(String.Format("A. Deposit\nB. Withdraw\nC. Close + Report\nR. Go Back"));
                    string optionS = Console.ReadLine().ToUpper();
                    switch (optionS)
                    {
                        case "A":
                            Console.WriteLine("Enter the amount you want to deposit:");
                            string stringAmountD = Console.ReadLine();
                            double.TryParse(stringAmountD, out double userAmountD);
                            A1.MakeDeposit(userAmountD);
                            break;
                        case "B":
                            Console.WriteLine("Enter the amount you want to withdraw:");
                            string stringAmountW = Console.ReadLine();
                            double.TryParse(stringAmountW, out double userAmountW);
                            A1.MakeWithdrawl(userAmountW);
                            break;
                        case "C":
                            A1.CloseAndReport();
                            break;
                        case "R":
                            Console.WriteLine(String.Format("A. Savings\nB. Checking\nC. Global Savings\nQ. Exit"));
                            option = Console.ReadLine().ToUpper();
                            break;
                        default:
                            Console.WriteLine("That's... Not what I'm looking for...");
                            break;
                    }
                    break;
                case "B":
                    Console.WriteLine(String.Format("A. Deposit\nB. Withdraw\nC. Close + Report\nR. Go Back"));
                    string optionC = Console.ReadLine().ToUpper();
                    switch (optionC)
                    {
                        case "A":
                            Console.WriteLine("Enter the amount you want to deposit:");
                            string stringAmountD = Console.ReadLine();
                            double.TryParse(stringAmountD, out double userAmountD);
                            A2.MakeDeposit(userAmountD);
                            break;
                        case "B":
                            Console.WriteLine("Enter the amount you want to withdraw:");
                            string stringAmountW = Console.ReadLine();
                            double.TryParse(stringAmountW, out double userAmountW);
                            A2.MakeWithdrawl(userAmountW);
                            break;
                        case "C":
                            A2.CloseAndReport();
                            break;
                        case "R":
                            Console.WriteLine(String.Format("A. Savings\nB. Checking\nC. Global Savings\nQ. Exit"));
                            option = Console.ReadLine().ToUpper();
                            break;
                        default:
                            Console.WriteLine("That's... Not what I'm looking for...");
                            break;
                    }
                    break;
                case "C":
                    Console.WriteLine(String.Format("A. Deposit\nB. Withdraw\nC. Close + Report\nD. Report Balance in USD\nR. Go Back"));
                    string optionGS = Console.ReadLine().ToUpper();
                    switch (optionGS)
                    {
                        case "A":
                            Console.WriteLine("Enter the amount you want to deposit:");
                            string stringAmountD = Console.ReadLine();
                            double.TryParse(stringAmountD, out double userAmountD);
                            A3.MakeDeposit(userAmountD);
                            break;
                        case "B":
                            Console.WriteLine("Enter the amount you want to withdraw:");
                            string stringAmountW = Console.ReadLine();
                            double.TryParse(stringAmountW, out double userAmountW);
                            A3.MakeWithdrawl(userAmountW);
                            break;
                        case "C":
                            A3.CloseAndReport();
                            break;
                        case "D":
                            A3.USValue(1.34);
                            break;
                        case "R":
                            Console.WriteLine(String.Format("A. Savings\nB. Checking\nC. Global Savings\nQ. Exit"));
                            option = Console.ReadLine().ToUpper();
                            break;
                        default:
                            Console.WriteLine("That's... Not what I'm looking for...");
                            break;
                    }
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("That's... Not what I'm looking for...");
                    break;
                }
            }
        }
    }
}
