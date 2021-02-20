namespace Facade.WeatherService.Models
{
    public class City
    {
        public City GetCityForEirCode(string eirCode)
        {
            return new City();
        }

        public string Name => "Galway";
    }
}