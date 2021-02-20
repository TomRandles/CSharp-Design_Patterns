using Factory.Business;
using Factory.Business.Models.Commerce;
using Factory.Business.Models.Shipping.AbstractFactory;
using Factory.Business.Models.Shipping.FactoryMethod;
using Factory.Business.Models.Shipping.FactoryProvider;
using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Create Order
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine().Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine().Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Tom Randles",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP In Depth", "C# In Depth", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
            #endregion

            // Shopping cart and shipping provider now decoupled - loose coupling
            // The particular concrete factory to use should be based on some user input or configuration at runtime
            // var cart = new ShoppingCart(order, new GlobalShippingProviderFactory());

            // New implementation using the Abstract Factory pattern

            IPurchaseProviderFactory purchaseProviderFactory;



            // Benefit of Factory Provider - simply extend the code with new country specific
            // purchase provider factories and they will automatically be picked up - no interference
            // with other coding

            var factoryProvider = new PurchaseProviderFactoryProvider();
            purchaseProviderFactory = factoryProvider.CreateFactoryFor(order.Sender.Country);

            if (purchaseProviderFactory == null)
            {
                throw new NotSupportedException("Provider for country not found");
            }

            // Code no longer required - use Factory provider instead
            //if (order.Sender.Country == "Sweden")
            //{
            //    purchaseProviderFactory = new SwedishPurchaseProviderFactory();
            //}
            //else if (order.Sender.Country == "Australia")
            //{
            //    purchaseProviderFactory = new AustraliaPurchaseProviderFactory();
            //}
            //else
            //    throw new Exception("Sender country not supported");

            var cart = new ShoppingCart(order, purchaseProviderFactory);
            var shippingLabel = cart.Finalize();

            Console.WriteLine(shippingLabel);
        }
    }
}
