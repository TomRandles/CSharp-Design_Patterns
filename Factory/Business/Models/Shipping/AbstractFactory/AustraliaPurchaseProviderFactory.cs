using Factory.Business.Models.Commerce;
using Factory.Business.Models.Commerce.Invoice;
using Factory.Business.Models.Commerce.Summary;
using Factory.Business.Models.Shipping.FactoryMethod;
using System;

namespace Factory.Business.Models.Shipping.AbstractFactory
{
    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTIInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProvider = new GlobalExpressShippingProviderFactory();
            return shippingProvider.CreateShippingProvider(order.Sender.Country);
        }

        ISummary IPurchaseProviderFactory.CreateSummary(Order order)
        {
            return new CSVSummary();
        }
    }
}