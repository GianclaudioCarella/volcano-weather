using Domain.VolcanoContext.Enums;
using Shared.Entities;
using System;

namespace Domain.VolcanoContext.Entities
{
    public class Weather : Entity
    {
        public Weather()
        {
        }

        public Weather(WeatherType type, string description, DateTime date, int planetPosition)
        {
            Type = type;
            Description = description;
            Date = date;
            PlanetPosition = planetPosition;
        }

        public WeatherType Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int PlanetPosition { get; set; }
    }
}
