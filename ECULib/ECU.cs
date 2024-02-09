using IECUSystemLib;
using IECUObserverLib;
using IOutsideTemperatureSensorLib;
using IPassengerCountSensorLib;
using ITemperatureCalculatorLib;
using ITemperatureRegulatorLib;


namespace ECULib
{
    public class ECU : IECUObserver, IECUSystem
    {
        public IOutsideTemperatureSensor? temperatureSensor;
        public IPassengerCountSensor? passengerCountSensor;

        public ITemperatureCalculator? calculator;
        public ITemperatureRegulator? regulator;

        private int lastReadTemperature;
        private int lastReadPassengerCount;

        public void SetOutsideTemperatureSensor(IOutsideTemperatureSensor temperatureSensor)
        {
            this.temperatureSensor = temperatureSensor;
        }

        public void SetPassengerCountSensor(IPassengerCountSensor passengerCountSensor)
        {
            this.passengerCountSensor = passengerCountSensor;
        }

        public void SetTemperatureCalculator(ITemperatureCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void SetTemperatureRegulator(ITemperatureRegulator regulator)
        {
            this.regulator = regulator;
        }

        public void SetNewTemperature()
        {
            if (calculator != null)
            {
                int newTemperature = calculator.CalculateNewTemperature(lastReadTemperature, lastReadPassengerCount);
                regulator?.SetRequiredTemperature(newTemperature);
            }
        }

        public void NotifyTemperature(int newTemperature)
        {
            lastReadTemperature = newTemperature;
            SetNewTemperature();
        }

        public void NotifyPassengerCount(int newCount)
        {
            lastReadPassengerCount = newCount;
            SetNewTemperature();
        }

        public void ActivateTemperatureSensor()
        {
            temperatureSensor?.RegisterObserver(this);
        }

        public void ActivatePassengerCountSensor()
        {
            passengerCountSensor?.RegisterObserver(this);
        }

        public void DeactivateTemperatureSensor()
        {
            temperatureSensor?.RemoveObserver();
        }

        public void DeactivatePassengerCountSensor()
        {
            passengerCountSensor?.RemoveObserver();
        }
    }
}