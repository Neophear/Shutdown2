using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Timers;
using System.Windows.Forms;

namespace Shutdown2
{
    public class DetailedTimer
    {
        private Timer timerSecond = new Timer();

        public CountdownTime WarningTime { get; set; }

        /// <summary>
        /// Fires when the Hour property changes
        /// </summary>
        public event EventHandler OnHourChange;
        public void HourChange()
        {
            EventHandler handler = OnHourChange;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fires when the Minute property changes
        /// </summary>
        public event EventHandler OnMinuteChange;
        public void MinuteChange()
        {
            EventHandler handler = OnMinuteChange;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fires when the Second property changes
        /// </summary>
        public event EventHandler OnSecondChange;
        public void SecondChange()
        {
            EventHandler handler = OnSecondChange;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fires when the warning time is reached
        /// </summary>
        public event EventHandler OnWarning;
        public void Warning()
        {
            EventHandler handler = OnWarning;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fires when timer reaches 0
        /// </summary>
        public event EventHandler OnTimerDone;
        public void TimerDone()
        {
            EventHandler handler = OnTimerDone;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns True or False depending on if the timer is running
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return timerSecond.Enabled;
            }
        }

        private int hour;
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
                HourChange();
            }
        }

        private int minute;
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
                MinuteChange();
            }
        }

        private int second;
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                second = value;
                SecondChange();
            }
        }

        /// <summary>
        /// Creates a new instance of DetailedTimer
        /// </summary>
        public DetailedTimer()
        {
            timerSecond.Interval = 1000;
            timerSecond.Tick += timerSecond_Tick;
            WarningTime = new CountdownTime(0, 1, 0);
        }

        /// <summary>
        /// Creates a new instance of DetailedTimer
        /// </summary>
        /// <param name="hour">Set hours</param>
        /// <param name="minute">Set minutes</param>
        /// <param name="second">Set seconds</param>
        public DetailedTimer(int hour, int minute, int second)
            : this()
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        void timerSecond_Tick(object sender, EventArgs e)
        {
            CountDownSecond();
        }

        private void CountDownSecond()
        {
            if (Second > 0)
            {
                Second--;
                if (WarningTime.Equals(new CountdownTime(Hour, Minute, Second)))
                    Warning();
            }
            else if (Minute > 0)
            {
                Second = 59;
                Minute--;
            }
            else if (Hour > 0)
            {
                Second = 59;
                Minute = 59;
                Hour--;

            }
            else
            {
                timerSecond.Stop();
                TimerDone();
            }
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            timerSecond.Start();
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            timerSecond.Stop();
        }

        /// <summary>
        /// Sets times
        /// </summary>
        /// <param name="hour">Set hours</param>
        /// <param name="minute">Set minutes</param>
        /// <param name="second">Set seconds</param>
        public void SetTimes(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        /// <summary>
        /// Sets times
        /// </summary>
        /// <param name="time">The countdown time</param>
        public void SetTimes(CountdownTime time)
        {
            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;
        }
    }

    public class CountdownTime : IComparable, IEquatable<object>
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public CountdownTime()
        {

        }
        public CountdownTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public static CountdownTime FromDateTime(DateTime time)
        {
            TimeSpan untilNextClock = time - DateTime.Now;

            if (untilNextClock.CompareTo(TimeSpan.Zero) < 0)
                untilNextClock.Add(new TimeSpan(24, 0, 0));

            return new CountdownTime(untilNextClock.Hours, untilNextClock.Minutes, untilNextClock.Seconds);
        }

        public static bool TryParse(string hour, string minute, string second, out CountdownTime countdownTime)
        {
            bool parsed = false;

            int tempHour = 0;
            int tempMinute = 0;
            int tempSecond = 0;

            if (hour == string.Empty)
                hour = "0";
            if (minute == string.Empty)
                minute = "0";
            if (second == string.Empty)
                second = "0";

            parsed = (int.TryParse(hour, out tempHour) && int.TryParse(minute, out tempMinute) && int.TryParse(second, out tempSecond));

            countdownTime = new CountdownTime(tempHour, tempMinute, tempSecond);

            return parsed;
        }

        public static CountdownTime Empty
        {
            get
            {
                return new CountdownTime(0, 0, 0);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            CountdownTime otherCDT = obj as CountdownTime;
            if (otherCDT != null)
            {
                if (Hour > otherCDT.Hour)
                    return 1;
                else if (Hour == otherCDT.Hour)
                {
                    if (Minute > otherCDT.Minute)
                        return 1;
                    else if (Minute == otherCDT.Minute)
                    {
                        if (Second > otherCDT.Second)
                            return 1;
                        else if (Second == otherCDT.Second)
                            return 0;
                    }
                }
                
                return -1;
            }
            else
            {
                throw new ArgumentException("Object is not a valid CountdownTime");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            CountdownTime otherCDT = obj as CountdownTime;
            if (Hour == otherCDT.Hour && Minute == otherCDT.Minute && Second == otherCDT.Second)
                return true;
            else
                return false;
        }

        public static bool operator <(CountdownTime time1, CountdownTime time2)
        {
            if (time1 == null || time2 == null)
                throw new ArgumentException("Object is not a valid CountdownTime");
            else
            {
                if (time1.Hour > time2.Hour)
                    return false;
                else if (time1.Hour == time2.Hour)
                {
                    if (time1.Minute > time2.Minute)
                        return false;
                    else if (time1.Minute == time2.Minute)
                    {
                        if (time1.Second > time2.Second)
                            return false;
                        else if (time1.Second == time2.Second)
                            return false;
                    }
                }

                return true;
            }
        }

        public static bool operator >(CountdownTime time1, CountdownTime time2)
        {
            if (time1 == null || time2 == null)
                throw new ArgumentException("Object is not a valid CountdownTime");
            else
            {
                if (time1 < time2 || time1 == time2)
                    return false;
                else
                    return true;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + Hour.GetHashCode();
                hash = (hash * 7) + Minute.GetHashCode();
                hash = (hash * 7) + Second.GetHashCode();
                return hash;
            }
        }
    }
}