using System.Text;

namespace Factory.Business.Models.Commerce.Invoice
{
    public class GSTIInvoice : IInvoice
    {
        public byte[] GenerateInterface()
        {
            return Encoding
                       .Default
                       .GetBytes("GST Invoice");
        }
    }
}