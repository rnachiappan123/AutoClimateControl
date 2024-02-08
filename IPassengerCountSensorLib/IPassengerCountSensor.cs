using ECULib;

namespace IPassengerCountSensorLib
{
    public interface IPassengerCountSensor
    {
        void RegisterObserver(ECU observer);
        void RemoveObserver();
    }
}
