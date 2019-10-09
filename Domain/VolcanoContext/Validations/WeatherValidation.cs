using Domain.VolcanoContext.Commands;
using FluentValidation;
using System;

namespace Domain.VolcanoContext.Validations
{
    public abstract class WeatherValidation<T> : AbstractValidator<T> where T : WeatherCommand
    {
        public WeatherValidation()
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Please specify a Type");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .Length(1, 20)
                .WithMessage("Invalid Description");
        }

        protected void ValidatePlanetPosition()
        {
            RuleFor(p => p.PlanetPosition)
                .LessThan(361)
                .GreaterThan(-1)
                .WithMessage("The planet position value must be between 0 and 360");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.WeatherId).NotEqual(Guid.Empty);
        }
    }
}
