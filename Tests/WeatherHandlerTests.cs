using Domain.VolcanoContext.Commands;
using Domain.VolcanoContext.Handlers;
using System;
using Tests.Mocks;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnSuccessWhenWeatherIsValid()
        {
            var handler = new WeatherHandler(new FakeWeatherRepository());
            var command = new NewWeatherCommand()
            {
                Type = Domain.VolcanoContext.Enums.WeatherType.Lluvia,
                Description = "Test",
                Date = DateTime.Now,
                PlanetPosition = 40
            };

            handler.Handle(command);
            Assert.True(command.IsValid());
        }
    }
}
