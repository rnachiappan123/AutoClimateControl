using IOutsideTemperatureSensorLib;
using IPassengerCountSensorLib;
using ITemperatureCalculatorLib;
using ITemperatureRegulatorLib;

namespace IECUSystemLib
{
    public interface IECUSystem
    {
        public void SetOutsideTemperatureSensor(IOutsideTemperatureSensor temperatureSensor);
        public void SetPassengerCountSensor(IPassengerCountSensor passengerCountSensor);
        public void SetTemperatureCalculator(ITemperatureCalculator calculator);
        public void SetTemperatureRegulator(ITemperatureRegulator regulator);
        public void SetNewTemperature();
        public void ActivateTemperatureSensor();
        public void ActivatePassengerCountSensor();
        public void DeactivateTemperatureSensor();
        public void DeactivatePassengerCountSensor();
    }
}
