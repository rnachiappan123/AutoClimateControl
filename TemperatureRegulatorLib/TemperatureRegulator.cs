using ITemperatureRegulatorLib;

namespace TemperatureRegulatorLib
{
    public class TemperatureRegulator : ITemperatureRegulator
    {
        private int requiredTemperature;

        public void SetRequiredTemperature(int newTemperature)
        {
            if (newTemperature < 18)
            {
                requiredTemperature = 18;
            }
            else if (newTemperature > 30)
            {
                requiredTemperature = 30;
            }
            else
            {
                requiredTemperature = newTemperature;
            }
        }
    }
}