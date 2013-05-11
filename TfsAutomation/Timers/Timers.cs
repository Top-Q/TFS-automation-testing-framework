using System;
using System.Collections.Generic;
using System.Linq;

namespace TfsAutomation.Timers
{
    public class Timers
    {
        private static Timers _instance;
        private static readonly object SyncOnject = new object();

        private Timers()
        {
            AutomationTimer = new List<Timer>();
        }

        private List<Timer> AutomationTimer { get; set; }

        public static Timers GetInstance
        {
            get
            {
                lock (SyncOnject)
                {
                    return (_instance) ?? (_instance = new Timers());
                }
            }
        }

        /// <summary>
        /// Creates and adds new named timer in list
        /// </summary>
        /// <param name="timerName">Name of timer will be added to list</param>
        /// <returns>
        /// True - if new timer was added succesfully to list
        /// False - if new timer was not added because old timer with same name found in list
        /// </returns>
        public bool CreateTimer(string timerName)
        {
            var timer = FindTimer(timerName);
            if (timer == null)
            {
                AutomationTimer.Add(new Timer(timerName));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes named timer from list
        /// </summary>
        /// <param name="timerName">Name of timer will be deleted from list</param>
        /// <returns>
        /// True - if named timer deleted from list
        /// False - if named timer not found
        /// </returns>
        public bool DeleteTimer(string timerName)
        {
            var timer = FindTimer(timerName);
            return AutomationTimer.Remove(timer);
        }

        public bool StartTimer(string timerName)
        {
            var timer = FindTimer(timerName);
            return timer != null && timer.Start();
        }

        public bool StopTimer(string timerName)
        {
            var timer = FindTimer(timerName);
            return timer != null && timer.Stop();
        }

        public bool IsTimer(string timerName)
        {
            var timer = FindTimer(timerName);
            return timer != null;
        }

        /// <summary>
        /// Returns string containes time from start of timer formated as hh:mm:ss
        /// </summary>
        /// <param name="timerName">Name of the timer</param>
        /// <returns>Instance of TimeSpan containes time interval from start</returns>
        public TimeSpan GetTimeStampAsTimeSpan(string timerName)
        {
            var timer = FindTimer(timerName);
            if (timer != null)
                return timer.GetTimeStampAsTimeSpan();
            return TimeSpan.MinValue;
        }

        /// <summary>
        /// Returns string containes time from start of timer formated as 'hh:mm:ss'
        /// </summary>
        /// <param name="timerName">Name of the timer</param>
        /// <returns>Formatted string</returns>
        public string GetTimeStampAsReadableString(string timerName)
        {
            var timer = FindTimer(timerName);
            return timer == null ? "" : timer.GetTimeStampAsReadableString();
        }

        /// <summary>
        /// Returns an instance of timer from list or null if the timer is not found
        /// </summary>
        /// <param name="timerName">Name of the timer</param>
        /// <returns></returns>
        private Timer FindTimer(string timerName)
        {
            return AutomationTimer == null ? null : AutomationTimer.FirstOrDefault(timer => timer != null && timer.Name.Equals(timerName));
        }
    }
}
