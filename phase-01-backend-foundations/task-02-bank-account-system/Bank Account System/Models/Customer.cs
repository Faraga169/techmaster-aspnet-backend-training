using System;
using System.Collections.Generic;
using System.Text;

namespace task_02_bank_account_system.Bank_Account_System.Models
{
    public class Customer
    {

        public Customer(string fullName,string email,int phoneNumber)
        {
            CustomerId = new Guid().ToString();
            FullName= fullName;
            Email= email;
            PhoneNumber = phoneNumber;
        }

        public string CustomerId { get; private set; }

        public  string FullName { get; private set; }

        public string Email { get; private set; }

        public  int PhoneNumber { get;private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    }
}
