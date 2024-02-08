using ECULib;
using OutsideTemperatureSensorLib;
using PassengerCountSensorLib;
using TemperatureCalculatorLib;
using TemperatureRegulatorLib;
using TimerControllerLib;

namespace AutoClimateControllerLib
{
    public class AutoClimateController
    {
        private readonly ECU ecu;

        public AutoClimateController(ECU ecuInstance)
        {
            ecu = ecuInstance;
            ecu.SetOutsideTemperatureSensor(new OutsideTemperatureSensor(new TimerController()));
            ecu.SetPassengerCountSensor(new PassengerCountSensor(new TimerController()));
            ecu.SetTemperatureCalculator(new TemperatureCalculator());
            ecu.SetTemperatureRegulator(new TemperatureRegulator());
        }

        public void On()
        {
            ecu.temperatureSensor?.RegisterObserver(ecu);
            ecu.passengerCountSensor?.RegisterObserver(ecu);
        }

        public void Off()
        {
            ecu.temperatureSensor?.RemoveObserver();
            ecu.passengerCountSensor?.RemoveObserver();
        }
    }
}