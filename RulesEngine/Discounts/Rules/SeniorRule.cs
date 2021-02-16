using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Discounts.Rules
{
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return .05m;
            }
            return 0;
        }
    }
}
