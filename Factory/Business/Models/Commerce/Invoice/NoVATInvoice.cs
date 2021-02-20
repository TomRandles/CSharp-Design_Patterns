using System.Text;

namespace Factory.Business.Models.Commerce.Invoice
{
    public class NoVATInvoice : IInvoice
    {
        public byte[] GenerateInterface()
        {
            return Encoding
           .Default
           .GetBytes("No VAT Invoice");
        }
    }
}