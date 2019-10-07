using Domain.VolcanoContext.Validations;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.VolcanoContext.Commands
{
    public class DeleteWeatherCommand : WeatherCommand
    {

        public override bool IsValid()
        {
            ValidationResult validationResult = new DeleteWeatherCommandValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}
