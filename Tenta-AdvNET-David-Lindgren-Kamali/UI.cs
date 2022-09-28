using HamsterDatabaseStructure;
using HamsterStuff;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Tenta_AdvNET_David_Lindgren_Kamali
{
    class UI
    {

        private static async Task Main()
        {
            int days = 0;
            bool daysTrue = false;

            int ticksPerSecond = 0;
            bool tickTrue = false;

            do
            {
                Console.WriteLine("How many days to iterate");
                daysTrue = int.TryParse(Console.ReadLine(), out days);
            } while (!daysTrue || days < 0);

            do
            {
                Console.WriteLine("How many ticks per second(MAX 10)?");
                tickTrue = int.TryParse(Console.ReadLine(), out ticksPerSecond);
            } while (!tickTrue || ticksPerSecond < 0 || ticksPerSecond > 10);

            for (int i = 1; i <= days; i++)
            {
                await Task.Run(() => RunHamster(ticksPerSecond, i));
                
                Console.ReadKey();

            }

        }


        private static async Task RunHamster(int ticksPerSecond, int day)
        {

            HamsterHandler hh = new HamsterHandler();
            Hamster h = new Hamster();
            HamsterTime ht = new HamsterTime();
            ActivityLog al = new ActivityLog();
            ExerciseArea eA = new ExerciseArea();

            var startTime = HamsterTime.TimeRead();

            Console.Clear();

            if (startTime.Hour != 7 && startTime.Minute != 0)
            {
                Console.WriteLine("The program did not exit as usual. A force reset will now occur");
                h.ForceReset();
                startTime = HamsterTime.TimeRead();
            }


            Console.WriteLine($"Day: {day}\n");

            Console.WriteLine($"StartTime: {startTime}\n");


            Console.WriteLine(await h.HamsterCheckIn(startTime, h));


            hh.Hamster += async (sender, e) => await HamsterDay(startTime, eA, h, hh);

            hh.StartTime(ticksPerSecond);

        }

        private static async Task HamsterDay(DateTime startTime, ExerciseArea eA, Hamster h, HamsterHandler hh)
        {
            string addTemp;
            string removeTemp;
            DateTime time = HamsterTime.TimeRead();

            int currentTick = HamsterTime.CurrentTick(startTime);

            if (currentTick < 99)
            {
                  addTemp = await eA.AddToExercise(h);
                   if(addTemp != "")
                    {
                        Console.WriteLine(addTemp);
                        
                    }
                    removeTemp = await eA.RemoveFromExercise(time, false, h);

                if (removeTemp != "")
                    {
                        Console.WriteLine(removeTemp);
                    }

                Console.WriteLine($"\n----------------------\n{HamsterTime.TimeWrite(time)}");
                Console.WriteLine($"Current tick: {HamsterTime.CurrentTick(startTime)}");
                Console.WriteLine($"{Hamster.AllTheHamsters()}");
            }

            else if(currentTick == 99)
            {
                removeTemp = await eA.RemoveFromExercise(time, true, h);
                Console.WriteLine(removeTemp);
                Console.WriteLine($"\n----------------------\n{HamsterTime.TimeWrite(time)}");
                Console.WriteLine($"Current tick: {HamsterTime.CurrentTick(startTime)}");
                Console.WriteLine($"{Hamster.AllTheHamsters()}");

            }

            else
            {
                hh.StopTime();
                Console.WriteLine(await h.HamsterCheckOut(startTime, eA, h));
            }

        }


    }
}
