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
