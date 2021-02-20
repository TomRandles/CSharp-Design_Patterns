using Factory.Business.Models.Commerce;
using Factory.Business.Models.Commerce.Invoice;
using Factory.Business.Models.Commerce.Summary;
using System.Collections.Generic;
using System.Text;

namespace Factory.Business.Models.Shipping.AbstractFactory
{
    // Abstract Factory pattern
    // Creational methods with a common theme.
    public interface IPurchaseProviderFactory
    {
        public ShippingProvider CreateShippingProvider(Order order);

        public IInvoice CreateInvoice(Order order);

        public ISummary CreateSummary(Order order);
    }


}
