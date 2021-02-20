using Factory.Business;
using Factory.Business.Models.Shipping.AbstractFactory;
using Factory.Tests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Factory.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestFinaliseOrderWithoutPurchaseProvider_NullReferenceException()
        {
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.CreateOrder();

            var cart = new ShoppingCart(order, null);

            cart.Finalize();
        }

        [TestMethod]
        public void TestFinaliseOrderWithSwedishtPurchaseProvider_NullReferenceException()
        {
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.CreateOrder();

            var purchaseProviderFactory =  new SwedishPurchaseProviderFactory();

            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }


    }
}
