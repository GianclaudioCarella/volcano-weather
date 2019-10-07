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

namespace API.Controllers
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
        public Weather Get(DateTime date)
        {
            return _repository.GetWeather(date);
        }

        [HttpPost]
        public ICommandResult Post([FromBody]NewWeatherCommand command)
        {
            var result = _handler.Handle(command);
            return result;

        }

    }
}