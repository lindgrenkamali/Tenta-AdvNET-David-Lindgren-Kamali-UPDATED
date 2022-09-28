using System;
using System.Threading;

namespace HamsterStuff

{
    public class HamsterHandler
    {

        public event EventHandler Hamster;
        public Timer HamsterTimer;

        public void StartTime(int tickPerSecond)
        {
            HamsterTimer = new Timer(TimerEvent, null, 1000, 1000 / tickPerSecond);
        }

        public void StopTime()
        {
            HamsterTimer.Change(Timeout.Infinite, Timeout.Infinite);
            
        }

        public void EventHamster(object sender, EventArgs e)
        {
            Hamster?.Invoke(sender, EventArgs.Empty);
        }

        public void TimerEvent(object t)
        {
            EventHamster(t, EventArgs.Empty);
        }


    }
}
