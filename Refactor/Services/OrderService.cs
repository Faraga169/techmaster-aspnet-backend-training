using System;
using System.Collections.Generic;
using System.Text;
using Refactor.Models;

namespace Refactor.Services
{
    public static class OrderService
    {
        private const decimal TaxRate=0.14m;
        private const decimal Shipping = 50;
        private const decimal FreeShippingThreshold = 1000m;
        private const decimal SilverDiscount = 0.05m;
        private const decimal GoldDiscount = 0.10m;
        private const decimal VipDiscount = 0.15m;
        public static decimal CalculateOrder(Order order) {


           
            if (order.Quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(order.Quantity), "Quantity must be positive");

            if(order.Price<=0)
                throw new ArgumentOutOfRangeException(nameof(order.Price), "Price must be positive");


            decimal total=CalculateSubTotal(order.Price,order.Quantity);

            decimal discount= CalculateDiscount(order.Customer.CustomerType,total);
           
            decimal afterDiscount = total - discount;

            decimal tax=CalculateTax(afterDiscount);


            return CalculateFinalTotal(afterDiscount, tax);


        }


        public static decimal CalculateSubTotal(decimal price,int quantity) {

           decimal total = price * quantity;
            return total;

        }

        public static decimal CalculateShipping(decimal afterDiscount)
        {
            return afterDiscount >= FreeShippingThreshold? 0: Shipping;
        }

        public static decimal CalculateFinalTotal(decimal afterDiscount, decimal tax)
        {
            decimal result;
            decimal shipping;

            shipping = CalculateShipping(afterDiscount);
           
            result = afterDiscount + tax + shipping;
            return result;

        }
        public static decimal CalculateTax(decimal afterDiscount)
        {

            decimal tax = afterDiscount * TaxRate;
            return tax;

        }

        public static decimal CalculateDiscount(CustomerType customerType,decimal total)
        {
            decimal discount;
            
            switch (customerType)
            {

                case CustomerType.Regular:
                    discount = 0;
                    break;
                case CustomerType.Silver:
                    discount = total * SilverDiscount;
                    break;

                case CustomerType.Gold:
                    discount = total * GoldDiscount;
                    break;

                case CustomerType.VIP:
                    discount = total * VipDiscount;
                    break;

                default:
                    throw new InvalidOperationException("Invalid customer type.");

            }

            return discount;

        }
    
}
}
