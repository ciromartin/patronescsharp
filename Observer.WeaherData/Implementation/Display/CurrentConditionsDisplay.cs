using Observer.WeaherData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.WeaherData.Implementation.Display
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private readonly ISubject _weatherData;

        private float _temperature;
        private float _humidity;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
        }

        public string Display()
        {
            return $"Current conditions: {_temperature}F degrees and {_humidity}% humidity";
        }

    }
}
