using Factory.Business.Models.Commerce;
using Factory.Business.Models.Commerce.Invoice;
using Factory.Business.Models.Commerce.Summary;
using Factory.Business.Models.Shipping.FactoryMethod;
using System;

namespace Factory.Business.Models.Shipping.AbstractFactory
{
    public class SwedishPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Sender.Country != order.Recipient.Country)
                return new NoVATInvoice();

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            // Example of including business logic in the factory class
            // Using pre-existing factories inside the Abstract Factory pattern

            ShippingProviderFactory shippingProviderFactory;
            if (order.Sender.Country != order.Recipient.Country)
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            else
                shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new IEmailSummary();
        }
    }
}
