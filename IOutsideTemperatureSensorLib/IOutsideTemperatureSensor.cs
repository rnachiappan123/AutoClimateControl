

namespace IOutSideTemperatureSensorLib
{
    public interface IOutsideTemperatureSensor
    {
        void RegisterObserver(ECU observer);
        void RemoveObserver();
    }
}
