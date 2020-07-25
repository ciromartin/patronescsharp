using Observer.WeaherData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.WeaherData.Implementation.Display
{
    public class ForcastDisplay : IObserver, IDisplayElement
    {
		private float _currentPressure = 29.92f;
		private float _lastPressure;
		private ISubject _weatherData;

		public ForcastDisplay(ISubject weatherData)
		{
			_weatherData = weatherData;
			_weatherData.RegisterObserver(this);
		}

		public void Update(float temperature, float humidity, float pressure)
		{
			_lastPressure = _currentPressure;
			_currentPressure = pressure;
		}

		public string Display()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("Forecast: ");

			if (_currentPressure > _lastPressure)
			{
				sb.Append("Improving weather on the way!");
			}
			else if (_currentPressure == _lastPressure)
			{
				sb.Append("More of the same");
			}
			else if (_currentPressure < _lastPressure)
			{
				sb.Append("Watch out for cooler, rainy weather");
			}

			return sb.ToString();
		}
	}
}
