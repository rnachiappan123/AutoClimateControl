using IECUObserverLib;

namespace IOutsideTemperatureSensorLib
{
    public interface IOutsideTemperatureSensor
    {
        void RegisterObserver(IECUObserver observer);
        void RemoveObserver();
    }
}
