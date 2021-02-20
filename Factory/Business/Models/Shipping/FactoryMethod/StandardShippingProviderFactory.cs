using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Business.Models.Shipping.FactoryMethod
{

    public class StandardShippingProviderFactory : ShippingProviderFactory
    {
        ShippingProvider _shippingProvider;

        // StandardShippingProvider
        
        public override ShippingProvider CreateShippingProvider(string country)
        {
            if (country == "Australia")
            {
                #region Australia Post Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 250,
                    extraWeightFee: 500
                )
                {
                    ShippingType = ShippingType.Standard
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PrePaid
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = false,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                _shippingProvider = new AustraliaPostShippingProvider("CLIENT_ID",
                                                                      "SECRET",
                                                                      shippingCostCalculator,
                                                                      customsHandlingOptions,
                                                                      insuranceOptions);
                #endregion
            }
            else if (country == "Sweden")
            {
                #region Swedish Postal Service Shipping Provider
                var shippingCostCalculator = new ShippingCostCalculator(
                    internationalShippingFee: 50,
                    extraWeightFee: 100
                )
                {
                    ShippingType = ShippingType.Express
                };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PayOnArrival
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = true,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                _shippingProvider = new SwedishPostalServiceShippingProvider("API_KEY",
                                                                            shippingCostCalculator,
                                                                            customsHandlingOptions,
                                                                            insuranceOptions);
             }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }
            #endregion

            return _shippingProvider;
        }
    }
}