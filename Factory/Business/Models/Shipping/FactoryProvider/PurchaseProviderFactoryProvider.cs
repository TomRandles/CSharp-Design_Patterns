using Factory.Business.Models.Shipping.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Factory.Business.Models.Shipping.FactoryProvider
{
    public class PurchaseProviderFactoryProvider
    {
        private IEnumerable<Type> factories;

        public PurchaseProviderFactoryProvider()
        {
            // Use Reflection to create a Factory Provider 
            // IPurchaseProviderFactory

            factories = Assembly.GetAssembly(typeof(PurchaseProviderFactoryProvider))
                                .GetTypes()
                                .Where(t => typeof(IPurchaseProviderFactory).IsAssignableFrom(t));
        }

        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            // Find a factory that corresponds to the parameter name 
            var factory = factories.Single(x =>
                x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            //Create instance of this class using Activator
            return (IPurchaseProviderFactory)Activator.CreateInstance(factory);
        }
    }
}
