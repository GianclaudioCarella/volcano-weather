using Domain.VolcanoContext.CalculeFunctions;
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
            using (WeatherCalculator _weatherCalculator = new WeatherCalculator())
            {
                var handler = new WeatherHandler(new FakeWeatherRepository(), _weatherCalculator);
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

        [Fact]
        public void ShouldReturnSuccessWhenVolcanoCalculatorIsValid()
        {
            using (WeatherCalculator _weatherCalculator = new WeatherCalculator())
            {
                //[0,5,10,15,20,25]
                var volcanoVelocity = 5;
                var index = 5;
                var position = _weatherCalculator.CalculePosition(index, volcanoVelocity);
                Assert.Equal(25, position);
            }
            
        }

        [Fact]
        public void ShoulReturnSuccessWhenBetasoideCalculatorIsValid()
        {
            using (WeatherCalculator _weatherCalculator = new WeatherCalculator())
            {
                //[0,3,6,9,12]
                var betasoideVelocity = 3;
                var index = 4;
                var position = _weatherCalculator.CalculePosition(index, betasoideVelocity);
                Assert.Equal(12, position);
            }
        }
        
        [Fact]
        public void ShouldReturnSuccessWhenFerengiCalculatorIsValid()
        {
            using (WeatherCalculator _weatherCalculator = new WeatherCalculator())
            {
                //[0,1,2,3,4,5]
                var ferengiVelocity = 1;
                var index = 3;
                var position = _weatherCalculator.CalculePosition(index, ferengiVelocity);
                Assert.Equal(3, position);
            }
        }
    }
}
