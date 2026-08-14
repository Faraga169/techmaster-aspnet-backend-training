using System;
using System.Collections.Generic;
using System.Text;

namespace task_02_bank_account_system.Bank_Account_System.Models
{
    public class BankAccount
    {
        public BankAccount(string accountNumber, Customer customer, AccountType accountType)
        {
            AccountNumber = accountNumber;
            Customer = customer;
            Balance = 0;
            AccountType = accountType;
            IsActive = true;
            Transactions = new List<Transaction>();

        }
        public  string AccountNumber { get; private set; }
        public  Customer Customer { get; private set; }

        public decimal Balance { get; private set; }

        public  AccountType AccountType { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public bool IsActive { get; private set; }

        public List<Transaction> Transactions { get; private set; }

        public void Deposit(decimal amount) {

            if (amount <= 0)
                return;


            Balance += amount;
          
        }

        public void WithDraw(decimal amount) {

            if (amount <= 0)
                return;


            if (amount > Balance)
                return;

            Balance -= amount;

        }

        public void AddTransaction(Transaction transaction) {

            Transactions.Add(transaction);
        }
    }
}
