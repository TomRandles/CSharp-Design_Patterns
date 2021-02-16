using System;

namespace RulesEngine.Discounts.Rules
{
    public class LoyalCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
                 customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
                 customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    if (isBirthday) return 0.25m;

                    return .15m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    if (isBirthday) return 0.22m;
                    return .12m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    if (isBirthday) return 0.20m;
                    return .10m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
                {
                    if (isBirthday) return 0.18m;
                    return .08m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                {
                    if (isBirthday) return 0.15m;
                    return .05m;
                }
            }
            return 0;
        }
    }
}
