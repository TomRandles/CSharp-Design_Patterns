using Factory.Business.Models.Commerce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Tests.Factories
{
    public abstract class OrderFactory
    {
        public abstract Order CreateOrder();

        public Order GetOrder()
        {
            var order = CreateOrder();

            // Include some content
            order.LineItems.Add(new Item("CSharp In Depth", "C# In Depth", 100m), 1);
            order.LineItems.Add(new Item("Consulting", "Building a website", 100m), 1);

            return order;
        }
    }

    public class StandardOrderFactory : OrderFactory
    {
        public override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Tom Randles",
                    Country = "Sweden"
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = "Australia"
                },

                TotalWeight = 200
            };
            return order;
        }
    }

    public class InternationalOrderFactory : OrderFactory
    {
        public override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Tom Randles",
                    Country = "USA"
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = "Australia"
                },

                TotalWeight = 200
            };
            return order;
        }
    }

}