using System;

namespace RulesEngine.Discounts
{
    public class DiscountCalculatorOriginal
    {
        // Original discount calculator highlighting complex logic that is difficult to maintain and update. 
        // Has very high cyclomatic method score.
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
                customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
                customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
            else
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    if (isBirthday) return 0.25m;

                    return .15m;
                }
                else if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    if (isBirthday) return 0.22m;

                    return .12m;
                }
                else if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    if (isBirthday) return 0.20m;

                    return .10m;
                }
                else if ((customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
                         && (!customer.IsVeteran))
                {
                    if (isBirthday) return 0.18m;

                    return .08m;
                }
                else if ((customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                         && (!customer.IsVeteran))
                {
                    if (isBirthday) return 0.15m;

                    return .05m;
                }
            }

            if (customer.IsVeteran)
            {
                if (isBirthday) return 0.20m;

                return 0.10m;
            }
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                if (isBirthday) return 0.15m;
                return 0.05m;
            }

            if (isBirthday) return 0.10m;

            return 0;
        }
    }
}
