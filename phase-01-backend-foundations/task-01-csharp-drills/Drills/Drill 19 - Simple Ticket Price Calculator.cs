using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace task_01_csharp_drills.Drills
{
    public static class Drill_19___Simple_Ticket_Price_Calculator
    {
        public static void TicketPriceCalculator(int age,string Flag)
        {
            decimal BasePrice = 100;
            decimal discount = 0;
            decimal FinalPrice;

            if (age < 12)
            {
                discount = decimal.Max(discount, 0.50m);
            }
            if (age > 60) {
                discount = decimal.Max(discount, 0.30m);
            }
            if (Flag.Equals("Yes", StringComparison.OrdinalIgnoreCase)) {
                discount = decimal.Max(discount, 0.20m);
            }

            FinalPrice = BasePrice * (1 - discount);
            Console.WriteLine(FinalPrice);
        }
    }
}
