using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderDesignPattern
{
    // Order build steps are executed under developer control
    // 
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            //Blank product item with every new builder instance
            Reset();

            _items = items;
        }

        private IEnumerable<FurnitureItem> _items;

        // Keep track of item its building
        private InventoryReport _report;

        // Keep report tracking clean and safe
        public void Reset()
        {
            _report = new InventoryReport();
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            _report.TitleSection = "Daily inventory report\n\n";
            return this;
        }
        public IFurnitureInventoryBuilder AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, 
                _items.Select(p => $"Product: {p.Name} \n Price: {p.Price}\n " +
                                $"Height: {p.Height} x Width: {p.Width} -> Weight {p.Weight} lbs.\n"
                ));
            return this;
        }
        public IFurnitureInventoryBuilder AddLogistics(DateTime date)
        {
            _report.LogisticsSection = $"Report generated on: {date.ToShortDateString()} " +
                                       $"{date.ToShortTimeString()}";
            return this;
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishedReport = _report;
            Reset();

            return finishedReport;
        }
    }
}