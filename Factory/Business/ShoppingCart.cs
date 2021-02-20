using Factory.Business.Models.Commerce;
using Factory.Business.Models.Shipping;
using Factory.Business.Models.Shipping.FactoryMethod;
using System;

namespace Factory.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly ShippingProviderFactory _shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            _shippingProviderFactory = shippingProviderFactory; ;
            this.order = order;
        }

        public string Finalize()    
        {
            // Shopping cart no longer cares about implementation details of shipping 
            // Recommend using GetShippingProvider
            var shippingProvider = _shippingProviderFactory.GetShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
