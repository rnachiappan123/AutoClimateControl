namespace IECUObserverLib
{
    public interface IECUObserver
    {
        void NotifyTemperature(int temperature);
        void NotifyPassengerCount(int passengerCount);
    }
}
