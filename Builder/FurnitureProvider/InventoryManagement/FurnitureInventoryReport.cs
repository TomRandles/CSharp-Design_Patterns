using System.Text;

namespace Builder.FurnitureProvider.InventoryManagement
{
 
    // Complex object to be given the Builder creation treatment
    // No constructor, will setup individual fields one by one. 
    public class FurnitureInventoryReport
    {
        public string TitleSection;
        public string DimensionsSection;
        public string LogisticsSection;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }
}