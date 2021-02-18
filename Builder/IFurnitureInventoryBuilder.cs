using System;

namespace BuilderDesignPattern
{
    // Builder interface should be general enough to apply
    // to all of the concrete builder classes that might apply in the future
    // Contains the method declarations necessary to build the conplex class. Add... etc.

    // Updated to align with Fluent Builder design pattern 
    // Each method returns its own object type. Permits chaining commands together

    public interface IFurnitureInventoryBuilder
    {
        IFurnitureInventoryBuilder AddTitle();
        IFurnitureInventoryBuilder AddDimensions();
        IFurnitureInventoryBuilder AddLogistics(DateTime date);

        // Return built item once it is complete
        // Normally part of concrete builder class. Here, general enough to include
        // in the interface
        InventoryReport GetDailyReport();

    }
}