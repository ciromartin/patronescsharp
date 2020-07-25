using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.WeaherData.Interfaces
{
    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }
}
