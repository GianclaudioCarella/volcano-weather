using Domain.VolcanoContext.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VolcanoContext.Validations
{
    public class DeleteWeatherCommandValidation : WeatherValidation<DeleteWeatherCommand>
    {
        public DeleteWeatherCommandValidation()
        {
            ValidateId();
        }
    }
}
