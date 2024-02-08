using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITemperatureCalculatorLib
{
    public interface ITemperatureCalculator
    {
        int CalculateNewTemperature(int newTemperature, int newPeopleCount);
    }
}
