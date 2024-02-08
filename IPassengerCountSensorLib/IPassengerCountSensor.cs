using IECUObserverLib;

namespace IPassengerCountSensorLib
{
    public interface IPassengerCountSensor
    {
        void RegisterObserver(IECUObserver observer);
        void RemoveObserver();
    }
}
