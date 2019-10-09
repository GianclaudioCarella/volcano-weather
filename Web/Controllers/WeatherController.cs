using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.VolcanoContext.Commands;
using Domain.VolcanoContext.Entities;
using Domain.VolcanoContext.Handlers;
using Domain.VolcanoContext.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _repository;
        private readonly WeatherHandler _handler;

        public WeatherController(IWeatherRepository repository, WeatherHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        public List<Weather> Get()
        {
            return _repository.GetWeathers();
        }

        [HttpGet("year")]
        public IEnumerable<VolcanoForecast> WeatherForecasts()
        {
            IList<string> weatherDays = new List<string>();

            for (int i = 0; i < 365; i++)
            {
                weatherDays.Add(_handler.GetWeather(i));
            }

            //return weatherDays;
            var rng = new Random();
            return Enumerable.Range(0, 364).Select(index => new VolcanoForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = weatherDays[index]
            });
        }

        [HttpPost]
        public IActionResult GenerateWeatherForNext10Years()
        {
            try
            {
                _handler.GenerateWeatherForNext10Years();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //public IEnumerable<VolcanoForecast> WeatherForecastByDate(DateTime date)
        //{
        //    DateTime startDate = new DateTime(2019, 01, 01);
        //    IList<string> weatherDays = new List<string>();
        //    TimeSpan span = date.Subtract(startDate);
        //    var difference = span.Days;

        //    while (startDate != date)
        //    {
        //        weatherDays.Add(_handler.GetWeather(date));
        //        date = date.AddDays(-1);
        //    }

        //    var rng = new Random();
        //    return Enumerable.Range(0, difference).Select(index => new VolcanoForecast
        //    {
        //        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = weatherDays[index]
        //    });
        //}



        public class VolcanoForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        //[HttpPost]
        //public ICommandResult Post([FromBody]NewWeatherCommand command)
        //{
        //    var result = _handler.Handle(command);
        //    return result;

        //}

    }
}