using System;

namespace RulesEngine.Discounts.Rules
{
    public class VeteranRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
                                  customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
                                  customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (customer.IsVeteran)
            {
                if (isBirthday) return 0.20m;

                return .10m;
            }
            return 0;
        }
    }
}
