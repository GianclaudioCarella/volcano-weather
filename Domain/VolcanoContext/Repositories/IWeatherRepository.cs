using Domain.VolcanoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VolcanoContext.Repositories
{
    public interface IWeatherRepository
    {
        List<Weather> GetWeathers();
        Weather GetWeather(DateTime date);
        void CreateWeather(Weather weather);
        void DeleteWeather(Guid idWeather);
        bool WeatherExists(DateTime date);
        int GetSequiaPeriods();
        int GetLluviaPeriods();
        int GetOptimoPeriods();
    }
}
