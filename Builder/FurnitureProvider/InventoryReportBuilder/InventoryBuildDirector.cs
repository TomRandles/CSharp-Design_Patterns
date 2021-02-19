using System;

namespace Builder.FurnitureProvider.InventoryBuilder
{
    // Job of director class - execute complex object build steps in a predetermined
    // sequence
    public class InventoryBuildDirector
    {
        private IFurnitureInventoryReportBuilder _builder;

        public InventoryBuildDirector(IFurnitureInventoryReportBuilder concreteBuilder)
        {
            _builder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDimensions(); 
            _builder.AddLogistics(DateTime.Now);
        }
    }
}