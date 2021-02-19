using Builder.FurnitureProvider.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder.FurnitureProvider.InventoryBuilder
{
    // Order build steps are executed under developer control
    // 
    public class DailyReportBuilder : IFurnitureInventoryReportBuilder
    {
        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            //Blank product item with every new builder instance
            Reset();

            _items = items;
        }

        private IEnumerable<FurnitureItem> _items;

        // Keep track of item its building
        private FurnitureInventoryReport _report;

        // Keep report tracking clean and safe
        public void Reset()
        {
            _report = new FurnitureInventoryReport();
        }

        public IFurnitureInventoryReportBuilder AddTitle()
        {
            _report.TitleSection = "Daily inventory report\n\n";
            return this;
        }
        public IFurnitureInventoryReportBuilder AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, 
                _items.Select(p => $"Product: {p.Name} \n Price: {p.Price}\n " +
                                $"Height: {p.Height} x Width: {p.Width} -> Weight {p.Weight} lbs.\n"
                ));
            return this;
        }
        public IFurnitureInventoryReportBuilder AddLogistics(DateTime date)
        {
            _report.LogisticsSection = $"Report generated on: {date.ToShortDateString()} " +
                                       $"{date.ToShortTimeString()}";
            return this;
        }

        public FurnitureInventoryReport GetDailyReport()
        {
            FurnitureInventoryReport finishedReport = _report;
            Reset();

            return finishedReport;
        }
    }
}