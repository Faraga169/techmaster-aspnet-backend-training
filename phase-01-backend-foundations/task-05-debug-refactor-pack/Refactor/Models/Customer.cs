using System;
using System.Collections.Generic;
using System.Text;

namespace Refactor.Models
{
    public class Customer
    {
        public Customer(string name,CustomerType customerType)
        {
            Name = name;
            CustomerType = customerType;
        }
        public string Name { get; private set; } = null!;

        public CustomerType CustomerType { get; private set; }
    }
}
