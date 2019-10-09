using Domain.VolcanoContext.CalculeFunctions;
using Domain.VolcanoContext.Commands;
using Domain.VolcanoContext.Entities;
using Domain.VolcanoContext.Enums;
using Domain.VolcanoContext.Repositories;
using Shared.Commands;
using System;
using System.Collections.Generic;

namespace Domain.VolcanoContext.Handlers
{
    public class WeatherHandler : ICommandHandler<NewWeatherCommand>
    {
        private readonly IWeatherRepository _repository;
        private readonly IWeatherCalculator _weatherCalculator;

        private const int VOLCANO_VELOCITY = 5;
        private const int BETASOIDE_VELOCITY = 3;
        private const int FERENGI_VELOCITY = 1;

        public WeatherHandler(
            IWeatherRepository repository,
            IWeatherCalculator weatherCalculator)
        {
            _repository = repository;
            _weatherCalculator = weatherCalculator;
        }

        public ICommandResult Handle(NewWeatherCommand command)
        {
            if (!command.IsValid())
                return new CommandResult(false, "Weather Invalid");

            //Generar las entidades
            var weather = new Weather(command.Type, command.Description, command.Date, command.PlanetPosition);

            //Guardar en la base
            _repository.CreateWeather(weather);

            return new CommandResult(true, "New Weather Day created");
        }

        /// <summary>
        /// Genera el clima para los proximos 10 anos (los guarda en la base de datos)
        /// </summary>
        public void GenerateWeatherForNext10Years()
        {
            var firstDay = new DateTime(2019, 01, 01);
            var countDay = new DateTime(2019, 01, 01);
            TimeSpan span = DateTime.Now.AddYears(10).Subtract(firstDay);
            var difference = span.Days;
            var countVolcano = 0;
            var countBetasoide = 0;
            var countFerengi = 0;
            var maxVolcano = 360 / 5;
            var maxBetasoide = 360 / 3;
            var maxFerengi = 360;

            while (difference != 0)
            {
                var volcanoPosition = _weatherCalculator.CalculePosition(countVolcano, VOLCANO_VELOCITY);
                var betasoidePosition = _weatherCalculator.CalculePosition(countBetasoide, BETASOIDE_VELOCITY);
                var ferengiPosicion = _weatherCalculator.CalculePosition(countFerengi, FERENGI_VELOCITY);

                string weaterVolcano = _weatherCalculator.GetWeather(volcanoPosition, betasoidePosition, ferengiPosicion);

                WeatherType type = WeatherType.Nublado;

                if (weaterVolcano == "Lluvia")
                    type = WeatherType.Lluvia;

                if (weaterVolcano == "Sequia")
                    type = WeatherType.Sequia;

                if (weaterVolcano == "Optimas Condiciones")
                    type = WeatherType.Optimo;

                //crea un nuevo commando para crear un weather
                Handle(new NewWeatherCommand(type, weaterVolcano, countDay, volcanoPosition));

                if (countVolcano == maxVolcano)
                    countVolcano = 0;
                if (countBetasoide == maxBetasoide)
                    countBetasoide = 0;
                if (countFerengi == maxFerengi)
                    countFerengi = 0;

                difference--;
                countVolcano++;
                countBetasoide++;
                countFerengi++;
                countDay = countDay.AddDays(1);
            }
        }

        /// <summary>
        /// Trae el clima de acuerdo a un dia en especifico
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public string GetWeather(int day)
        {
            var volcanoPosition = _weatherCalculator.CalculePosition(day, VOLCANO_VELOCITY);
            var betasoidePosition = _weatherCalculator.CalculePosition(day, BETASOIDE_VELOCITY);
            var ferengiPosicion = _weatherCalculator.CalculePosition(day, FERENGI_VELOCITY);

            return _weatherCalculator.GetWeather(volcanoPosition, betasoidePosition, ferengiPosicion);
        }

    }
}
