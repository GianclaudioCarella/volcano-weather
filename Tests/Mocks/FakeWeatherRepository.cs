using System;
using System.Collections.Generic;
using Domain.VolcanoContext.Entities;
using Domain.VolcanoContext.Repositories;

namespace Tests.Mocks
{
    public class FakeWeatherRepository : IWeatherRepository
    {
        public void CreateWeather(Weather weather)
        {
            //throw new NotImplementedException();
        }

        public void DeleteWeather(Guid idWeather)
        {
            //throw new NotImplementedException();
        }

        public Weather GetWeather()
        {
            return new Weather()
            {
                Date = DateTime.Now,
                Description = "Test",
                Type = Domain.VolcanoContext.Enums.WeatherType.Lluvia,
                PlanetPosition = 40
            };
        }

        public List<Weather> GetWeathers(int year)
        {
            List<Weather> weatherList = new List<Weather>();
            weatherList.Add(new Weather()
            {
                Date = DateTime.Now,
                Description = "Test",
                Type = Domain.VolcanoContext.Enums.WeatherType.Lluvia,
                PlanetPosition = 40
            });
            weatherList.Add(new Weather()
            {
                Date = DateTime.Now.AddDays(+1),
                Description = "Test2",
                Type = Domain.VolcanoContext.Enums.WeatherType.Sequia,
                PlanetPosition = 45
            });
            weatherList.Add(new Weather()
            {
                Date = DateTime.Now.AddDays(+2),
                Description = "Test3",
                Type = Domain.VolcanoContext.Enums.WeatherType.Optimo,
                PlanetPosition = 50
            });

            return weatherList;
        }

        public bool WeatherExists(DateTime date)
        {
            if (date.Equals(new DateTime(2019, 9, 04)))
                return false;

            return true;
        }
    }
}
