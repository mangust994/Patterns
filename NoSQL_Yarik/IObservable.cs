using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyUpdateObservers();
        void NotifyCreateObservers();
        void NotifyDeleteObservers();
    }
}
