using System;
using System.Linq;
using System.Collections.Generic;
using Domain.VolcanoContext.Entities;
using Infrastructure.VolcanoContext.DataContexts;
using Domain.VolcanoContext.Repositories;
using Domain.VolcanoContext.Enums;

namespace Infrastructure.VolcanoContext.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly VolcanoDbContext _context;

        public WeatherRepository(VolcanoDbContext context)
        {
            _context = context;
        }

        public List<Weather> GetWeathers()
        {
            return _context.Weathers.ToList();
        }

        public Weather GetWeather(DateTime date)
        {
            return _context.Weathers.Where(w => w.Date.Date.Equals(date.Date)).FirstOrDefault();
        }

        public List<Weather> GetWeathersByYear(int year)
        {
            return _context.Weathers.Where(w => w.Date.Year.Equals(year)).ToList();
        }

        public List<Weather> GetWeathersByMonth(int month)
        {
            return _context.Weathers.Where(m => m.Date.Month.Equals(month)).ToList();
        }

        public void CreateWeather(Weather weather)
        {
            _context.Add(weather);
            _context.SaveChanges();
        }

        public void DeleteWeather(Guid id)
        {
            var weather = _context.Weathers.Find(id);
            _context.Remove(weather);
            _context.SaveChanges();
        }

        public bool WeatherExists(DateTime date)
        {
            var weather = _context.Weathers.Where(w => w.Date.Date.Equals(date.Date)).FirstOrDefault();
            if (weather == null)
                return false;
            return true;

        }

        public int GetSequiaPeriods()
        {
            return _context.Weathers.Where(w => w.Type.Equals(WeatherType.Sequia)).Count();
        }

        public int GetLluviaPeriods()
        {
            return _context.Weathers.Where(w => w.Type.Equals(WeatherType.Lluvia)).Count();
        }

        public int GetOptimoPeriods()
        {
            return _context.Weathers.Where(w => w.Type.Equals(WeatherType.Optimo)).Count();
        }
    }
}
