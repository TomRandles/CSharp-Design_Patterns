using Facade.WeatherService.Models;
using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            const string eirCode = "H81 XR2M";

            IWeatherReportFacade weatherFacade = new WeatherReportFacade();
            WeatherFacadeResults results = weatherFacade.GetTempInCity(eirCode);

            Console.WriteLine("The current temperature is {0}F/{1}C in {2}, {3}",
                                results.Fahrenheit,
                                results.Celsius,
                                results.City.Name,
                                results.County.Name);
        }
    }
}
