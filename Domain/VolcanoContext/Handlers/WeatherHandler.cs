using Domain.VolcanoContext.Commands;
using Domain.VolcanoContext.Entities;
using Domain.VolcanoContext.Repositories;
using Shared.Commands;

namespace Domain.VolcanoContext.Handlers
{
    public class WeatherHandler : ICommandHandler<NewWeatherCommand>
    {
        private readonly IWeatherRepository _repository;

        public WeatherHandler(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(NewWeatherCommand command)
        {
            // Verificar si fecha weather ya existe
            if (_repository.WeatherExists(command.Date))
            {
                return new CommandResult(false, $"The weather for {command.Date} is {command.Type}.");
            }

            if (command.IsValid())
                return new CommandResult(false, "Weather Invalid");

            // Hacer la cuenta para saber cual es el dia

            //Generar las entidades
            var weather = new Weather(command.Type, command.Description, command.Date, command.PlanetPosition);

            //Guardar
            _repository.CreateWeather(weather);

            return new CommandResult(true, "New Weather Day created");
        }

        public ICommandResult Handle(GenerateWeatherYearCommand command)
        {
            //generar todos os Weathers do ano
            //guardar en la tabla
            return new CommandResult(false, "Falta implementar");
        }
    }
}
