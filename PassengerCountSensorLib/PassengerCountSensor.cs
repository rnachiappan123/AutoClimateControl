using IECUObserverLib;
using IPassengerCountSensorLib;
using ITimerControllerLib;

namespace PassengerCountSensorLib
{
    public class PassengerCountSensor : IPassengerCountSensor
    {
        private int peopleCount;
        private IECUObserver? observer;
        private readonly ITimerController timer;

        public PassengerCountSensor(ITimerController timer)
        {
            this.timer = timer;
            timer.SetTimer(5000);
            timer.SetTimerElapsedAction(new Action(ReadPassengerCount));
        }

        private void ReadPassengerCount()
        {
            Random rnd = new Random();
            peopleCount = rnd.Next(0, 5);
            NotifyObservers();
        }

        public void RegisterObserver(IECUObserver observer)
        {
            this.observer = observer;
            timer.StartTimer();
        }

        public void RemoveObserver()
        {
            observer = null;
            timer.StopTimer();
        }

        private void NotifyObservers()
        {
            observer?.NotifyPassengerCount(peopleCount);
        }
    }
}