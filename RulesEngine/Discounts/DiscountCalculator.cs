using RulesEngine.Discounts.Rules;
using RulesEngine.Discounts.RulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesEngine.Discounts
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            var ruleType = typeof(IDiscountRule);
            IEnumerable<IDiscountRule> rules = this.GetType().Assembly.GetTypes()
                .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(r => Activator.CreateInstance(r) as IDiscountRule);

            var engine = new DiscountRulesEngine(rules);

            return engine.CalculateDiscountPercentage(customer);
        }
    }
}
