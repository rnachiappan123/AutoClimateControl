using ITemperatureCalculatorLib;

namespace TemperatureCalculatorLib
{
    public class TemperatureCalculator : ITemperatureCalculator
    {
        public int CalculateNewTemperature(int outsideTemp, int peopleCount)
        {
            return Convert.ToInt32(Math.Round(25 - (outsideTemp - 25) * peopleCount * 0.1));
        }
    }
}