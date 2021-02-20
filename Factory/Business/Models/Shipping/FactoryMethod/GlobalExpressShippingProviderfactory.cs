namespace Factory.Business.Models.Shipping.FactoryMethod
{
    public class GlobalExpressShippingProviderfactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalExpressShippingProvider();
        }
    }
}