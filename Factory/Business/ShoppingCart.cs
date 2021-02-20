using Factory.Business.Models.Commerce;
using Factory.Business.Models.Shipping;
using Factory.Business.Models.Shipping.AbstractFactory;
using Factory.Business.Models.Shipping.FactoryMethod;
using System;

namespace Factory.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly IPurchaseProviderFactory _shippingProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory shippingProviderFactory)
        {
            _shippingProviderFactory = shippingProviderFactory; ;
            this.order = order;
        }

        public string Finalize()    
        {
            // Shopping cart no longer cares about implementation details of shipping 
            // Recommend using GetShippingProvider

            // Finalise - involves shipping provider, invoice and order. Ideal for Abstract Factory pattern

            var shippingProvider = _shippingProviderFactory.CreateShippingProvider(order);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
