using IECUObserverLib;
using IOutsideTemperatureSensorLib;
using ITimerControllerLib;

namespace OutsideTemperatureSensorLib
{
    public class OutsideTemperatureSensor : IOutsideTemperatureSensor
    {
        private int temperature;
        private IECUObserver? observer;
        private readonly ITimerController timer;

        public OutsideTemperatureSensor(ITimerController timer)
        {
            this.timer = timer;
            timer.SetTimer(3000);
            timer.SetTimerElapsedAction(new Action(ReadTemperature));
        }

        private void ReadTemperature()
        {
            Random rnd = new Random();
            temperature = rnd.Next(15, 45);
            NotifyObservers();
        }

        public void RegisterObserver(IECUObserver observer)
        {
            this.observer = observer;
            timer.StartTimer();
        }

        public void RemoveObserver()
        {
            this.observer = null;
            timer.StopTimer();
        }

        private void NotifyObservers()
        {
            observer?.NotifyTemperature(temperature);
        }
    }
}