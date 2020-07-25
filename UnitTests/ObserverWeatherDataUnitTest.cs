using FluentAssertions;
using Observer.WeaherData.Implementation.Data;
using Observer.WeaherData.Implementation.Display;
using Xunit;

namespace UnitTests
{
    public class ObserverWeatherDataUnitTest
    {
        private readonly WeatherData _weatherData;
        private readonly CurrentConditionsDisplay _currentConditionsDisplay;
        private readonly ForcastDisplay _forcastDisplay;
        private readonly StatisticsDisplay _statisticsDisplay;
        private readonly HeatIndexDisplay _heatIndexDisplay;

		public ObserverWeatherDataUnitTest()
        {
            _weatherData = new WeatherData();
            _currentConditionsDisplay = new CurrentConditionsDisplay(_weatherData);
            _forcastDisplay = new ForcastDisplay(_weatherData);
            _statisticsDisplay = new StatisticsDisplay(_weatherData);
            _heatIndexDisplay = new HeatIndexDisplay(_weatherData);
        }

		[Fact]
		public void WeatherData_ShouldBeEmpyObservers_WhenIsInstantiate()
		{
			//Arrange
			var weather = new WeatherData();

			//Assert
			weather.Observers.Should().HaveCount(0);
		}

		[Fact]
		public void WeatherData_ShouldHaveObservers_WhenRegisterObservers()
		{
			//Arrange
			var weather = new WeatherData();
			new CurrentConditionsDisplay(weather);
			new CurrentConditionsDisplay(weather);

			//Assert
			weather.Observers.Should().HaveCount(2);
		}

		[Fact]
		public void WeatherData_ShouldBeEmpty_WhenUnregisterObservers()
		{
			//Arrange
			var weather = new WeatherData();
			var display = new CurrentConditionsDisplay(weather);
			weather.UnregisterObserver(display);

			//Assert
			weather.Observers.Should().BeEmpty();
		}

		[Fact]
        public void CurrentConditionsDisplay_ShouldDisplay_WhenMeasurementsChanged()
        {
			//Act
			_weatherData.SetMeasurements(80, 65, 30.4f);
			var display = _currentConditionsDisplay.Display();

			//Assert
			display.Should().Be("Current conditions: 80F degrees and 65% humidity");
        }

		[Fact]
		public void ForcastDisplay_ShouldDisplayImproving_WhenMeasurementsChanged()
		{
			//Act
			_weatherData.SetMeasurements(81, 63, 31.2f);
			var display = _forcastDisplay.Display();

			//Assert
			display.Should().Be("Forecast: Improving weather on the way!");
		}

		[Fact]
		public void ForcastDisplay_ShouldDisplayCooler_WhenMeasurementsChanged()
		{
			//Act
			_weatherData.SetMeasurements(81, 63, 31.2f);
			_weatherData.SetMeasurements(81, 63, 29.92f);
			var display = _forcastDisplay.Display();

			//Assert
			display.Should().Be("Forecast: Watch out for cooler, rainy weather");
		}

		[Fact]
		public void ForcastDisplay_ShouldDisplaySame_WhenSameMeasurementsChanged()
		{
			//Act
			_weatherData.SetMeasurements(81, 63, 29.92f);
			_weatherData.SetMeasurements(81, 63, 29.92f);
			var display = _forcastDisplay.Display();

			//Assert
			display.Should().Be("Forecast: More of the same");
		}

		[Fact]
		public void HeatIndexDisplay_ShouldDisplay_WhenMeasurementsChanged()
		{
			//Act
			_weatherData.SetMeasurements(80, 65, 31.2f);
			var display = _heatIndexDisplay.Display();

			//Assert
			display.Should().Be("Heat index is 82.95535");
		}

		[Fact]
		public void StatisticsDisplay_ShouldDisplay_WhenMeasurementsChanged()
		{
			//Act
			_weatherData.SetMeasurements(80, 63, 31.2f);
			_weatherData.SetMeasurements(81, 63, 29.92f);
			_weatherData.SetMeasurements(84, 63, 29.92f);
			var display = _statisticsDisplay.Display();

			//Assert
			display.Should().Be("Avg/Max/Min temperature = 81.67F/84F/80F");
			_statisticsDisplay.NumberOfReadings.Should().Be(3);
		}
	}
}
