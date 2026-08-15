using System.Globalization;
using System.Transactions;
using task_02_bank_account_system.Bank_Account_System.Models;
using task_02_bank_account_system.Bank_Account_System.Services;
using task_02_bank_account_system.Bank_Account_System.UI;
using Transaction = task_02_bank_account_system.Bank_Account_System.Models.Transaction;

namespace task_02_bank_account_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int option;
            bool flag;
           
            while (!exit)
            {
                Console.Clear();
                do
                {
                    ConsoleMenu.ShowMenu();
                    flag = int.TryParse(Console.ReadLine(), out option);
                } while (!flag);


                
                switch (option)
                {
                    
                    case 1:
                        string accountNumber;
                        try {
                            Console.Clear();
                            Console.WriteLine("===== Create Customer Account =====");

                            Console.Write("Enter Full Name: ");
                            string fullName = Console.ReadLine() ?? "";

                            while (string.IsNullOrWhiteSpace(fullName))
                            {
                                Console.Write("Enter a valid Full Name: ");
                                fullName = Console.ReadLine() ?? "";
                            }

                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine() ?? "";

                            while (string.IsNullOrWhiteSpace(email))
                            {
                                Console.Write("Enter a valid Email: ");
                                email = Console.ReadLine() ?? "";
                            }

                            Console.Write("Enter Phone: ");
                            int phoneNumber;

                            while (!int.TryParse(Console.ReadLine(), out phoneNumber))
                            {
                                Console.Write("Enter a valid Phone: ");
                            }


                            Console.WriteLine("Choose Account Type:");
                            Console.WriteLine("1. Savings");
                            Console.WriteLine("2. Current");
                            Console.Write("Choose: ");

                            AccountType accountType;

                            while (!Enum.TryParse(Console.ReadLine(), out accountType) || !Enum.IsDefined(typeof(AccountType), accountType))
                            {
                                Console.Write("Choose a valid Account Type: ");
                            }


                            Console.Write("Enter Account Number: ");
                             accountNumber = Console.ReadLine() ?? "";

                            while (string.IsNullOrWhiteSpace(accountNumber))
                            {
                                Console.Write("Enter a valid Account Number: ");
                                accountNumber = Console.ReadLine() ?? "";

                            }

                            Customer customer = new Customer(fullName, email, phoneNumber);

                            BankService.AccountCreation(customer, accountNumber, accountType);

                            Console.WriteLine("Account created successfully!");
                            Console.WriteLine($"Account Number: {accountNumber}");
                          

                        }

                        catch (Exception ex) {

                            Console.WriteLine($"Operation failed: {ex.Message}");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 2:
                    case 3:
                    case 4:
                        {
                            Console.Clear();

                            TransactionType transactionType;
                            string? fromAccountNumber=null;
                            string? toAccountNumber=null;
                            try
                            {

                                if (option == 2)
                                {
                                    transactionType = TransactionType.Deposit;
                                    Console.Write("Enter a To Account Number: ");

                                    toAccountNumber = Console.ReadLine() ?? "";
                                    while (string.IsNullOrWhiteSpace(toAccountNumber))
                                    {
                                        Console.Write("Enter a valid To Account Number: ");
                                        toAccountNumber = Console.ReadLine() ?? "";
                                    }


                                }

                                else if (option == 3)
                                {
                                    transactionType = TransactionType.withDraw;
                                    Console.Write("Enter From Account Number: ");
                                    fromAccountNumber = Console.ReadLine();

                                    while (string.IsNullOrWhiteSpace(fromAccountNumber))
                                    {
                                        Console.Write("Enter a valid From Account Number: ");
                                        fromAccountNumber = Console.ReadLine() ?? "";
                                    }
                                }


                                else
                                {
                                    transactionType = TransactionType.Transfer;
                                    Console.Write("Enter From Account Number: ");
                                    fromAccountNumber = Console.ReadLine();

                                    Console.Write("Enter To Account Number: ");
                                    toAccountNumber = Console.ReadLine();

                                    while (string.IsNullOrWhiteSpace(fromAccountNumber) || string.IsNullOrWhiteSpace(toAccountNumber))
                                    {
                                        Console.Write("Enter From Account Number: ");
                                        fromAccountNumber = Console.ReadLine();

                                        Console.Write("Enter To Account Number: ");
                                        toAccountNumber = Console.ReadLine();
                                    }


                                }



                                Console.Write("Enter Amount: ");
                                decimal amount;

                                while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                                {
                                    Console.Write("Enter a valid positive amount: ");
                                }



                                Console.Write("Enter Description: ");
                                string? description = Console.ReadLine() ?? null;

                                Transaction transaction = new Transaction(fromAccountNumber!, toAccountNumber!, transactionType, amount, description!);
                                BankService.Transfer(transaction);
                                Console.WriteLine("Transaction is Done Successfully!");
                              
                            }

                            catch (Exception ex) {

                                Console.WriteLine($"Operation failed: {ex.Message}");
                            }

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        }

                    case 5:
                        Console.Clear();

                        Console.Write("Enter Account Number: ");
                        accountNumber = Console.ReadLine() ?? "";

                        while (string.IsNullOrWhiteSpace(accountNumber))
                        {
                            Console.Write("Enter a valid Account Number: ");
                            accountNumber = Console.ReadLine() ?? "";
                        }

                        BankService.ViewAccountDetails(accountNumber);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.Clear();

                        Console.Write("Enter Account Number: ");
                        accountNumber = Console.ReadLine() ?? "";

                        while (string.IsNullOrWhiteSpace(accountNumber))
                        {
                            Console.Write("Enter a valid Account Number: ");
                            accountNumber = Console.ReadLine() ?? "";
                        }

                        BankService.TransactionHistory(accountNumber);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.Clear();
                        BankService.ViewAllAccounts();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.Clear();
                        exit = true;
                        Console.WriteLine("GoodBye");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.Write("Your Choice is Wrong must be in Range From 1 to 8 ");
                      
                        break;

                }
             

            }
        }
    }
}

