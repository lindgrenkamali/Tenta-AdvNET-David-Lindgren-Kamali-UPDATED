using System;
using System.IO;

namespace HamsterStuff
{
    public class HamsterTime
    {
        private static object fileLocker = new object();

        public static DateTime TimeRead()
        {
            lock (fileLocker)
            {
                string path = Directory.GetCurrentDirectory();
                path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));

                using (StreamReader sr = new StreamReader(path + "Time.txt"))
                {
                    string time = sr.ReadLine();

                    DateTime timeDate = Convert.ToDateTime(time);

                    return timeDate;
                }
            }

        }

        public static string TimeWrite(DateTime time)
        {
            var currentTime = HamsterTime.TimeRead();

                lock (fileLocker)
                {
                string path = Directory.GetCurrentDirectory();
                path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));

                using (StreamWriter sw = new StreamWriter(path + "Time.txt"))
                    {
                        currentTime = time.AddMinutes(6);
                        sw.WriteLine(currentTime.ToString());

                        return currentTime.ToString();

                    }
                }

        }

        public static void NewDay()
        {
            var currentTime = TimeRead();

            var time = currentTime.ToString("yyyy-MM-dd");

            var specifiedTime = $"{time} 07:00:00";

            DateTime nextDay = DateTime.Parse(specifiedTime).AddDays(1);

            lock (fileLocker)
            {
                string path = Directory.GetCurrentDirectory();
                path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));

                using (StreamWriter sw = new StreamWriter(path + "Time.txt"))
                {

                    sw.WriteLine(nextDay);
                }
            }

        }

        public static int CurrentTick(DateTime startTime)
        {
            var currentTime = TimeRead();
            var hours = currentTime.Subtract(startTime).Hours;

            var minutes = currentTime.Subtract(startTime).Minutes;

            if (hours >= 1)
            {
                minutes += 60 * hours;
            }

            var ticks = minutes / 6;

            return ticks;


        }
    }
}
