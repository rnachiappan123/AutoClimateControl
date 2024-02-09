using ECULib;
using OutsideTemperatureSensorLib;
using PassengerCountSensorLib;
using TemperatureCalculatorLib;
using TemperatureRegulatorLib;
using TimerControllerLib;
using IECUSystemLib;

namespace AutoClimateControllerLib
{
    public class AutoClimateController
    {
        private readonly IECUSystem ecu;

        public AutoClimateController(IECUSystem ecuInstance)
        {
            ecu = ecuInstance;
            ecu.SetOutsideTemperatureSensor(new OutsideTemperatureSensor(new TimerController()));
            ecu.SetPassengerCountSensor(new PassengerCountSensor(new TimerController()));
            ecu.SetTemperatureCalculator(new TemperatureCalculator());
            ecu.SetTemperatureRegulator(new TemperatureRegulator());
        }

        public void On()
        {
            ecu.ActivateTemperatureSensor();
            ecu.ActivatePassengerCountSensor();
        }

        public void Off()
        {
            ecu.DeactivateTemperatureSensor();
            ecu.DeactivatePassengerCountSensor();
        }
    }
}