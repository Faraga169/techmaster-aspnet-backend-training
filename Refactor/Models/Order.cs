using System;
using System.Collections.Generic;
using System.Text;

namespace Refactor.Models
{
    public class Order
 {
        public Order(string productName,decimal price,int quantity,Customer customer)
        {
            ProductName = productName;
            Price=price;
            Customer = customer;
        }

        public string ProductName { get; private set; } = null!;

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public Customer Customer { get; private set; } = null!;

    }
}
