using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Discounts.Rules
{
    public class FirstTimeCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
            return 0;
        }
    }
}
