using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClimateControl
{
    public interface IPassengerCountSensor
    {
        void RegisterObserver(ECU observer);
        void RemoveObserver();
    }
}
