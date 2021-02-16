﻿using System;

namespace RulesEngine.Discounts
{
    public class DiscountCalculatorComplexLogic
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return .15m;
            }
            else
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    return .15m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    return .12m;
                }
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    return .10m;
                }
                if ((customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
                         && (!customer.IsVeteran))
                {
                    return .08m;
                }
                if ((customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
                         && (!customer.IsVeteran))
                {
                    return .05m;
                }
            }

            if (customer.IsVeteran)
            {
                return 0.10m;
            }

            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return 0.05m;
            }

            return 0;
        }
    }
}