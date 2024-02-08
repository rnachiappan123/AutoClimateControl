using ITemperatureRegulatorLib;

namespace TemperatureRegulatorLib
{

    public class TemperatureRegulator : ITemperatureRegulator
    {
        private int requiredTemperature;

        public void SetRequiredTemperature(int newTemperature)
        {
            requiredTemperature = newTemperature;

            if (requiredTemperature < 18)
            {
                requiredTemperature = 18;
            }
            if (requiredTemperature > 30)
            {
                requiredTemperature = 30;
            }
        }
    }
}
