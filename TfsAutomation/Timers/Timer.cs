using System;

namespace TfsAutomation.Timers
{
    public class Timer
    {
        public string Name { get; private set; }        // Name of Timer
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }

        private bool IsStarted { get; set; }            // Gets true if timer have started now
        private bool WasStarted { get; set; }           // Gets true if timer was started once up on time

        private Timer() {}

        public Timer (string name)
        {
            if (name == null || name.Equals(""))
                throw new Exception("Can't create timer withno name");
            Name = name;
            StartTime = new DateTime();
            EndTime = new DateTime();
            IsStarted = false;
            WasStarted = false;
        }

        public bool Start()
        {
            if (IsStarted) return false;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            IsStarted = true;
            WasStarted = true;
            return true;
        }

        public bool Stop()
        {
            if (!IsStarted) return false;
            EndTime = DateTime.Now;
            IsStarted = false;
            return true;
        }

        public TimeSpan GetTimeStampAsTimeSpan()
        {
            return IsStarted
                       ? DateTime.Now.Subtract(StartTime)
                       : WasStarted ? EndTime.Subtract(StartTime) : TimeSpan.MinValue;
        }

        public string GetTimeStampAsReadableString()
        {
            var interval = IsStarted
                                ? DateTime.Now.Subtract(StartTime)
                                : WasStarted ? EndTime.Subtract(StartTime) : TimeSpan.MinValue;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:000}", interval.Hours, interval.Minutes, interval.Seconds, interval.Milliseconds);
        }

        public static String ConvertTimeToReadableString(TimeSpan time)
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:000}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
        }

        public static String ConvertTimeToReadableStringSec(TimeSpan time)
        {
            return "" + time.TotalSeconds;            
        }
    }
}
