using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Business.Models.Shipping.FactoryMethod
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);

        public ShippingProvider GetShippingProvider(string country)
        {
            // Provides some flexibility before returning the shipping provider
            // to the client.
            // Inject dependencies if required
            
            var provider =  CreateShippingProvider(country);

            // Put code here that is common to all shipping providers
            if (country == "Sweden" && provider.InsuranceOptions.ProviderHasInsurance)
                provider.RequireSignature = false;

            return provider;
        }
    }
}