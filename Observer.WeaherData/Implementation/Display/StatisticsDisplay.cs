using Observer.WeaherData.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Observer.WeaherData.Implementation.Display
{
    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private readonly ISubject _weatherData;

		private float _maxTemp = 0.0f;
		private float _minTemp = 200;
		private float _temperatureSum = 0.0f;
		private int _numReadings = 0;

		public StatisticsDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

		public int NumberOfReadings
		{
			get
			{
				return _numReadings;
			}
		}

		public void Update(float temperature, float humidity, float pressure)
		{
			_temperatureSum += temperature;
			_numReadings++;

			if (temperature > _maxTemp)
			{
				_maxTemp = temperature;
			}

			if (temperature < _minTemp)
			{
				_minTemp = temperature;
			}
		}

		public string Display()
		{
			return $"Avg/Max/Min temperature = {RoundFloatToString(_temperatureSum / _numReadings)}F/{_maxTemp}F/{_minTemp}F";
		}

		public static string RoundFloatToString(float floatToRound)
		{
			var cultureInfo = new CultureInfo("en-US");
			cultureInfo.NumberFormat.NumberDecimalDigits = 2;
			cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
			return floatToRound.ToString("F", cultureInfo);
		}
	}
}
