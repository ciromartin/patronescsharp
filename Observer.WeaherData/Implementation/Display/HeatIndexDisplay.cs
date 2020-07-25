using Observer.WeaherData.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Observer.WeaherData.Implementation.Display
{
    public class HeatIndexDisplay : IObserver, IDisplayElement
    {
        private float _heatIndex = 0.0f;
        private readonly ISubject _weatherData;

        public HeatIndexDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _heatIndex = ComputeHeatIndex(temperature, humidity);
        }

        private float ComputeHeatIndex(float temperature, float relativeHumidity)
        {
            float heatIndex = (float)((16.923 + (0.185212 * temperature) +
                (5.37941 * relativeHumidity) - (0.100254 * temperature * relativeHumidity) +
                (0.00941695 * (temperature * temperature)) +
                (0.00728898 * (relativeHumidity * relativeHumidity)) +
                (0.000345372 * (temperature * temperature * relativeHumidity)) -
                (0.000814971 * (temperature * relativeHumidity * relativeHumidity)) +
                (0.0000102102 * (temperature * temperature * relativeHumidity * relativeHumidity)) -
                (0.000038646 * (temperature * temperature * temperature)) +
                (0.0000291583 * (relativeHumidity * relativeHumidity * relativeHumidity)) +
                (0.00000142721 * (temperature * temperature * temperature * relativeHumidity)) +
                (0.000000197483 * (temperature * relativeHumidity * relativeHumidity * relativeHumidity)) -
                (0.0000000218429 * (temperature * temperature * temperature * relativeHumidity * relativeHumidity)) +
                0.000000000843296 * (temperature * temperature * relativeHumidity * relativeHumidity * relativeHumidity)) -
                (0.0000000000481975 * (temperature * temperature * temperature * relativeHumidity * relativeHumidity * relativeHumidity)));
            return heatIndex;
        }

        public string Display()
        {
            return $"Heat index is {RoundFloatToString(_heatIndex)}" ;
        }

        public static string RoundFloatToString(float floatToRound)
        {
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalDigits = 5;
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            return floatToRound.ToString("F", cultureInfo);
        }
    }
}
