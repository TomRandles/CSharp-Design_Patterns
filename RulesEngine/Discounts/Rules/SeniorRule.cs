using System;

namespace RulesEngine.Discounts.Rules
{
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
                                  customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
                                  customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                if (isBirthday) return 0.15m;
                return .05m;
            }
            return 0;
        }
    }
}
