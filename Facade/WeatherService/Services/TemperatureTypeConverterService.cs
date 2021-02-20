namespace Facade.WeatherService.Services
{
    public class TemperatureTypeConverterService
    {
        public int ConvertFahrenheitToCelsius(int fahrenheit)
        {
            double celsius = (5.0 / 9.0) * (fahrenheit - 32);
            
            return (int) celsius;
        }
        
        public int ConvertCelsiusToFahrenheit(int celsius)
        {
            double fahrenheit = celsius * (1.8 + 32);
            
            return (int) fahrenheit;
        }
    }
}