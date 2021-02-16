using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Discounts.Rules
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }
}
