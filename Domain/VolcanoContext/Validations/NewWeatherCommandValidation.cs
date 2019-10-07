using Domain.VolcanoContext.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VolcanoContext.Validations
{
    class NewWeatherCommandValidation : WeatherValidation<NewWeatherCommand>
    {
        public NewWeatherCommandValidation()
        {
            ValidateDescription();
            ValidatePlanetPosition();
        }
    }
}
