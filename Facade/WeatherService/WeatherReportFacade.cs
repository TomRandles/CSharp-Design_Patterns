using Facade.WeatherService.Services;
using Facade.Services;
using Facade.WeatherService.Models;

namespace Facade
{
    public class WeatherReportFacade : IWeatherReportFacade
    {
        private readonly TemperatureTypeConverterService _converterService;
        private readonly GeoLookupService _geoLookUpService;
        private readonly WeatherReportService _weatherService;

        public WeatherReportFacade() : 
            this(new TemperatureTypeConverterService(), new GeoLookupService(), new WeatherReportService())
        {
            
        }
        
        public WeatherReportFacade(TemperatureTypeConverterService converterService,
                                GeoLookupService geoLookUpService,
                                WeatherReportService weatherService)
        {
            _converterService = converterService;
            _geoLookUpService = geoLookUpService;
            _weatherService = weatherService;
        }

        public WeatherFacadeResults GetTempInCity(string eirCode)
        {
            City city = _geoLookUpService.GetCityForZipCode(eirCode);
            County county = _geoLookUpService.GetStateForEirCode(eirCode);
            int tempF = _weatherService.GetTempFahrenheit(city, county);
            int tempC = _converterService.ConvertFahrenheitToCelsius(tempF);

            var results = new WeatherFacadeResults
            {
                City = city,
                County = county,
                Fahrenheit = tempF,
                Celsius = tempC
            };
            
            return results;
        }
    }
}