using HamsterDatabaseStructure;
using HamsterStuff;
using System;
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
                Console.WriteLine("How many ticks per second? MAX 5");
                tickTrue = int.TryParse(Console.ReadLine(), out ticksPerSecond);
            } while (!tickTrue || ticksPerSecond < 0 || ticksPerSecond > 5);

            for (int i = 1; i <= days; i++)
            {
                await Task.Run(() => RunHamster(ticksPerSecond, i));

                
                Console.ReadKey();

            }

            while (true)
            {

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

            if (startTime.Hour != 7)
            {
                Console.WriteLine("The program did not exit as usual. A force reset will now occur");
                h.ForceReset();
                startTime = HamsterTime.TimeRead();
            }


            Console.WriteLine($"Day: {day}\n");

            Console.WriteLine($"StartTime: {startTime}\n");


            Console.WriteLine(await h.HamsterCheckIn(startTime, h));


            hh.Hamster += async (sender, e) => await HamsterDay(startTime, eA, h);

            hh.StartTime(ticksPerSecond);


            do
            {
                Thread.Sleep(200);

            } while (HamsterTime.CurrentTick(startTime) < 100);
            Console.WriteLine(await h.HamsterCheckOut(startTime, hh, eA, h));

        }

        private static async Task HamsterDay(DateTime startTime, ExerciseArea eA, Hamster h)
        {
            string addTemp;
            string removeTemp;
            DateTime time = HamsterTime.TimeRead();

            int currentTick = HamsterTime.CurrentTick(time);

            if (currentTick < 100)
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
                   
                }
                
                Console.WriteLine($"\n----------------------\n{HamsterTime.TimeWrite(time)}");
                Console.WriteLine($"Current tick: {HamsterTime.CurrentTick(startTime)}");
                Console.WriteLine($"{Hamster.AllTheHamsters()}");
            

        }


    }
}
