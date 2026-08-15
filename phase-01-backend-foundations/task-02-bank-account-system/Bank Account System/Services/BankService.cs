using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Transactions;
using task_02_bank_account_system.Bank_Account_System.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Transaction = task_02_bank_account_system.Bank_Account_System.Models.Transaction;

namespace task_02_bank_account_system.Bank_Account_System.Services
{
    public static class BankService
    {
        public static List<Customer> Customers { get; private set; } = new List<Customer>();
        public static List<BankAccount> BankAccounts { get; private set; } = new List<BankAccount>();
        public static void AccountCreation(Customer customer,string accountNumber,AccountType accountType) {
            if(customer is null)
                throw new ArgumentNullException(nameof(customer));

            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number is required.");

            if (BankAccounts.Any(a => a.AccountNumber == accountNumber))
                throw new InvalidOperationException("Account already exists.");

            var Account = new BankAccount(accountNumber, customer, accountType);
            if (!Customers.Contains(customer))
            {
                Customers.Add(customer);
            }           
            BankAccounts.Add(Account);

        }

        public static void Transfer(Transaction transaction)
        {
            var fromAccount = BankAccounts.Find(a => a.AccountNumber == transaction.FromAccountNumber);

            var toAccount = BankAccounts.Find(a => a.AccountNumber == transaction.ToAccountNumber);


            if (transaction.TransactionType == TransactionType.Deposit)
            {
                if (toAccount is null)
                    throw new InvalidOperationException("to account not found.");

                if(!toAccount.IsActive)
                    throw new InvalidOperationException("to account is not Active.");

                if (toAccount.Deposit(transaction.Amount))
                {
                    transaction.SetBalanceAfterTransaction(toAccount.Balance);
                    toAccount.AddTransaction(transaction);
                }

                else {
                    throw new InvalidOperationException("Deposit failed. Amount must be greater than zero.");

                }
            }

            else if (transaction.TransactionType == TransactionType.withDraw)
            {
                if (fromAccount is null)
                    throw new InvalidOperationException("From account not found.");

                if (!fromAccount.IsActive)
                    throw new InvalidOperationException("From account is not Active.");

                if (fromAccount.WithDraw(transaction.Amount))
                {
                    transaction.SetBalanceAfterTransaction(fromAccount.Balance);
                    fromAccount.AddTransaction(transaction);
                }
                else
                {
                    throw new InvalidOperationException("WithDraw failed. Amount must be less than or equal Balance..");

                }
            }

            else if (transaction.TransactionType == TransactionType.Transfer)
            {
                if (fromAccount is null || toAccount is null)
                    throw new InvalidOperationException("Account not found.");

                if (!fromAccount.IsActive||!toAccount.IsActive)
                    throw new InvalidOperationException("account is not Active.");

                if (fromAccount == toAccount)
                    throw new InvalidOperationException("Cannot transfer to the same account.");

                var withdrawResult = fromAccount.WithDraw(transaction.Amount);

                if (!withdrawResult)
                    
                            throw new InvalidOperationException("Transfer failed. Amount must be less than or equal Balance.");
              

                var depositResult = toAccount.Deposit(transaction.Amount);

                if (!depositResult)

                    throw new InvalidOperationException("Transfer failed. Amount must be greater than zero.");
               

               

                transaction.SetBalanceAfterTransaction(fromAccount.Balance);
                transaction.SetBalanceAfterTransaction(toAccount.Balance);

                fromAccount.AddTransaction(transaction);
                toAccount.AddTransaction(transaction);
            }
        }

        public static void TransactionHistory(string AccountNumber) {

            var account = BankAccounts.Find(a => a.AccountNumber == AccountNumber);

            if (account is null)
                throw new InvalidOperationException("Account Number Not Found");

            if (account.Transactions is null || account.Transactions.Count == 0)
            {

                Console.WriteLine("No Transactions until now");
            }
            else {

                var transactionHistory = account.Transactions.OrderByDescending(t => t.TransactionDate);

                Console.WriteLine("===== Transaction History =====");

                foreach (var transaction in transactionHistory)
                {
                    Console.WriteLine(
                        $"Type: {transaction.TransactionType} | " +
                        $"Amount: {transaction.Amount} | " +
                        $"Date: {transaction.TransactionDate} | " +
                        $"Description: {transaction.Description} | " +
                        $"Balance After: {transaction.BalanceAfterTransaction}"
                    );
                }

          
            }

        }

        public static void ViewAccountDetails(string AccountNumber) {

            var account = BankAccounts.Find(a => a.AccountNumber == AccountNumber);

            if (account is null)
                throw new InvalidOperationException("Account Number Not Found");

            Console.WriteLine("===== Account Details =====");
            Console.WriteLine($"Account Number : {account.AccountNumber}");
            Console.WriteLine($"Customer Name  : {account.Customer.FullName}");
            Console.WriteLine($"Email          : {account.Customer.Email}");
            Console.WriteLine($"Phone          : {account.Customer.PhoneNumber}");
            Console.WriteLine($"Account Type   : {account.AccountType}");
            Console.WriteLine($"Balance        : {account.Balance}");
            Console.WriteLine($"Created Date   : {account.CreatedAt}");
            Console.WriteLine($"Status         : {(account.IsActive ? "Active" : "Inactive")}");

        }

        public static void ViewAllAccounts()
        {


            Console.WriteLine("===== Bank Accounts =====");

            if (BankAccounts.Count == 0 || BankAccounts is null)
            {

                Console.WriteLine("No Accounts until now");
            }
            else {

                for (int i = 0; i < BankAccounts.Count; i++)
                {
                    var account = BankAccounts[i];

                    Console.WriteLine($"Account Number : {account.AccountNumber}");
                    Console.WriteLine($"Customer Name  : {account.Customer.FullName}");
                    Console.WriteLine($"Type           : {account.AccountType}");
                    Console.WriteLine($"Balance        : {account.Balance}");
                    Console.WriteLine($"Status         : {(account.IsActive ? "Active" : "Inactive")}");
                    Console.WriteLine("-------------------------------");
                
            }


        }

    }

            }
           



        
    }
    

