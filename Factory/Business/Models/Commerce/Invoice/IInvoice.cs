using System;
using System.Collections.Generic;

namespace Factory.Business.Models.Commerce.Invoice
{
    public interface IInvoice
    {
        public byte[] GenerateInterface();
    }
}