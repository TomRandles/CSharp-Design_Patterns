using RulesEngine.Discounts.Rules;
using System;
using System.Collections.Generic;

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
                // Invoke the rule and replace the current discount if greater
                discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
            }
            return discount;
        }
    }
}