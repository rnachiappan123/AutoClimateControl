using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITimerControllerLib
{
    public interface ITimerController
    {
        void SetTimer(double interval);
        void SetTimerElapsedAction(Action OnTimerElapsed);
        void StartTimer();
        void StopTimer();
    }
}
