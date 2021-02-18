using System;
using System.Collections.Generic;

namespace BuilderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            var inventoryBuilder = new DailyReportBuilder(items);


            // Use Fluent Builder capabilities directly with the concrete builder instead 
            // of the director
            // var director = new InventoryBuildDirector(inventoryBuilder);

            //director.BuildCompleteReport();
            //var directorReport = inventoryBuilder.GetDailyReport();

            var fluentReport = inventoryBuilder
                                    .AddTitle()
                                    .AddDimensions()
                                    .AddLogistics(DateTime.Now)
                                    .GetDailyReport();


            System.Console.WriteLine(fluentReport.Debug());
        }
    }
}