using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.WeaherData.Interfaces
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers();
    }
}
