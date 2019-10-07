using Domain.VolcanoContext.Enums;
using Domain.VolcanoContext.Validations;
using FluentValidation.Results;
using Shared.Commands;
using System;

namespace Domain.VolcanoContext.Commands
{
    public abstract class WeatherCommand : ICommand
    {
        public Guid WeatherId { get; set; }
        public WeatherType Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int PlanetPosition { get; set; }

        public abstract bool IsValid();
    }
}
