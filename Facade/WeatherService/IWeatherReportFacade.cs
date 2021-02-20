using Facade.WeatherService.Models;

namespace Facade
{
    public interface IWeatherReportFacade
    {
        WeatherFacadeResults GetTempInCity(string eirCode);
    }
}