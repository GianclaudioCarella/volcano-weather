using Domain.VolcanoContext.Enums;
using Domain.VolcanoContext.Validations;
using FluentValidation.Results;
using System;

namespace Domain.VolcanoContext.Commands
{
    public class NewWeatherCommand : WeatherCommand
    {
        public NewWeatherCommand()
        {
        }

        public NewWeatherCommand(WeatherType type, string description, DateTime date, int planetPosition)
        {
            Type = type;
            Description = description;
            Date = date;
            PlanetPosition = planetPosition;
        }

        

        public override bool IsValid()
        {
            ValidationResult validationResult = new NewWeatherCommandValidation().Validate(this);
            return validationResult.IsValid;
        }

    }
}
