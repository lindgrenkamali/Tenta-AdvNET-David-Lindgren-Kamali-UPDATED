using HamsterStuff;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterDatabaseStructure
{


    public class Hamster
    {
        [Key]
        public int Id { get; set; }

        public string HamsterName { get; set; }

        public int Age { get; set; }

        [MaxLength(1)]
        public string Gender { get; set; }

        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public int? CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public int? ExerciseAreaId { get; set; }
        public virtual ExerciseArea ExerciseArea { get; set; }

        public DateTime? CheckInTime { get; set; } = null;

        public DateTime? LatestMotion { get; set; } = null;


        //Används en del av
        public static string AllTheHamsters()
        {

            using (var hdc = HamsterDbContext.CreateDb())
            {
                var hamsterInCage = hdc.Hamsters.Where(x => x.CageId != null).Count();
                var hamsterInExercise = hdc.Hamsters.Where(x => x.ExerciseAreaId != null).Count();
                var hamsterNotInCages = hdc.Hamsters.Where(x => x.CageId == null && x.ExerciseAreaId == null).Count();

                var hamsterCageNames = Cage.HamstersInCage();
                var hamsterExerciseNames = ExerciseArea.HamstersInExercise();

                string tickReport = $"\nHamsters in cage: {hamsterInCage}";



                //foreach (var name in hamsterCageNames)
                //{

                //    tickReport += $"\n{name}";
                //}

                tickReport += $"\nHamsters in exercise: {hamsterInExercise}";

                //foreach (var name in hamsterExerciseNames)
                //{
                //    tickReport += $"\n{name}";
                //}


                return tickReport;
            }

        }

        //Sätter in hamstrarna i burar
        public async Task<string> HamsterCheckIn(DateTime time, Hamster h)
        {

            return await Cage.ToCage(time, h);

        }

        //Kollar vilken hamster som har det ID:et och returnerar namnet
        public string RecieveHamsterName(int id)
        {
            using (var hdc = HamsterDbContext.CreateDb())
            {
                string hamsterName = hdc.Hamsters.Where(x => x.Id == id).Select(x => x.HamsterName).SingleOrDefault();
                return hamsterName;
            }
        }


        //Avslutar dagen
        public async Task<string> HamsterCheckOut(DateTime time, HamsterHandler hh, ExerciseArea eA, Hamster h)
        {
            ActivityLog al = new ActivityLog();
            DateTime currentTime = HamsterTime.TimeRead();
            int tick = HamsterTime.CurrentTick(time);
            string goingHome;

            var hamsterResult = al.EndOfDayResult(h, time);

            await eA.RemoveFromExercise(time, true, h);
            using (var hdc = HamsterDbContext.CreateDb())
            {


                var hamsterNull = (from ha in hdc.Hamsters
                                   where ha.CageId != null
                                   select ha).ToList();


                foreach (var hamster in hamsterNull)
                {
                    hamster.CageId = null;
                    hamster.CheckInTime = null;
                    hamster.LatestMotion = null;

                    var activityLog = new ActivityLog { ActivityId = 2, HamsterId = hamster.Id, TimeStamp = time };

                    hdc.ActivityLogs.Add(activityLog);

                }

                goingHome = "\n----------------------\nAll hamsters going home";

                await hdc.SaveChangesAsync();

                foreach (var hamster in hamsterResult)
                {
                    goingHome += hamster;
                }

            }
            
            HamsterTime.NewDay();
            return goingHome;
        }

        //Återställer programmet
        public void ForceReset()
        {
            using (var hdc = HamsterDbContext.CreateDb())
            {
                var resetHamster = hdc.Hamsters.Select(x => x);
                foreach (var hamster in resetHamster)
                {
                    hamster.CageId = null;
                    hamster.ExerciseAreaId = null;
                    hamster.CheckInTime = null;
                    hamster.LatestMotion = null;
                    HamsterTime.NewDay();
                }
            }
        }
    }
}
