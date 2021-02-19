using Builder.ApplianceManagement.ApplianceBuilder;
using Builder.FurnitureProvider.InventoryBuilder;
using System;
using System.Collections.Generic;

namespace Builder
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


            Console.WriteLine(fluentReport.Debug());

            Console.WriteLine("Create new Heat Pump manager instance using the Builder design pattern");

            var builder = new ApplianceManagerBuilder(ApplianceType.HeatPump);

            var heatPumpManager = 
                builder.AddApplianceManagerIdentifiers("HeatPump00657", "OvumHeatPump056")
                   .AddIPConfiguration("192.168.45.01", 502)
                   .AddAppServerConfiguration(3000, 2)
                   .GetApplianceManager();

            Console.WriteLine(heatPumpManager.Debug());

            Console.WriteLine("Create new Fan Coil Unit manager instance using the Builder design pattern");
            builder = new ApplianceManagerBuilder(ApplianceType.FanCoilUnit);

            var fanCoilUnit =
                builder.AddApplianceManagerIdentifiers("FanCoil00699", "Aertesi Zefiro 805")
                   .AddIPConfiguration("192.168.45.02", 502)
                   .AddAppServerConfiguration(3000, 3)
                   .GetApplianceManager();

            Console.WriteLine(fanCoilUnit.Debug());


        }
    }
}