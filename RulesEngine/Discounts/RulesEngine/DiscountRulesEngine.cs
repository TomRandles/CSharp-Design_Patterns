using RulesEngine.Discounts.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Discounts.RulesEngine
{
    public class DiscountRulesEngine
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();

        public DiscountRulesEngine(IEnumerable<IDiscountRule> rules)
        {
            _rules.AddRange(rules);
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0m;
            foreach (var rule in _rules)
            {
                discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
            }
            return discount;
        }
    }
}
