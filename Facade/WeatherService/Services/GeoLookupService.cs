using Facade.WeatherService.Models;

namespace Facade.WeatherService.Services
{
    public class GeoLookupService
    {
        public City GetCityForZipCode(string zipCode)
        {
            // a lookup would occur here
            return new City();
        }
        
        public County GetStateForEirCode(string eirCode)
        {
            return new County();
        }

        public City GetCityForCoordinates(double longitude, double latitude)
        {
            return new City();
        }
        
        public City GetStateByCapital(string capital)
        {
            return new City();
        }
    }
}