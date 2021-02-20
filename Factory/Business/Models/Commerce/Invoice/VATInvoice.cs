using System.Text;

namespace Factory.Business.Models.Commerce.Invoice
{
    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInterface()
        {
            return Encoding
           .Default
           .GetBytes("VAT Invoice");
        }
    }
}