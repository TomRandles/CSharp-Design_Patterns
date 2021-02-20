using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);

        void Send();
    }

    public class IEmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is an email summary of order: ";
        }

        public void Send()
        {
            
        }
    }

    public class CSVSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is a CSV summary of order";
        }

        public void Send()
        {
        }
    }
}
