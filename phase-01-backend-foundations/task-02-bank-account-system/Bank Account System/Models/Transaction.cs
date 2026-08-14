using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace task_02_bank_account_system.Bank_Account_System.Models
{
    public class Transaction
    {
        // TransactionId
        //AccountNumber
        //TransactionType
        //Amount
        //TransactionDate
        //Description
        //BalanceAfterTransaction

        public Transaction(string fromAccountNumber, string toAccountNumber, TransactionType transactionType,decimal amount,string description)
        {
            TransactionId= new Guid().ToString();
            FromAccountNumber= fromAccountNumber;
            ToAccountNumber= toAccountNumber;
            Amount= amount;
            TransactionType = transactionType;
            Description = description;
            
        }

        public  string TransactionId{ get; private set; }

        public string? FromAccountNumber { get; private set; }
        public string? ToAccountNumber { get; private set; }

        public  decimal Amount { get; private set; }

        public TransactionType TransactionType { get;private  set; }


        public DateTime TransactionDate { get; private set; } = DateTime.UtcNow;

        public string? Description { get; private set; }

        public decimal BalanceAfterTransaction { get; private set; }


        public void SetBalanceAfterTransaction(decimal balance)
        {
            BalanceAfterTransaction = balance;
        }
    }
}
