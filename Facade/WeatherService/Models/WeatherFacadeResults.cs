namespace Facade.WeatherService.Models
{
    public class WeatherFacadeResults
    {
        public int Fahrenheit { get; set; }
        public int Celsius { get; set; }
        public City City { get; set; }
        public County County { get; set; }
    }
}