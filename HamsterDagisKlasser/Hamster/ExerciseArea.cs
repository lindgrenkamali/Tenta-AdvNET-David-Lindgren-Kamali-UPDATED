using HamsterStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterDatabaseStructure
{
    public class ExerciseArea
    {
        [Key]
        [MaxLength(1)]
        public int Id { get; set; }
        public int MaxSize { get; set; } = 6;
        public ICollection<Hamster> Hamster { get; set; }


        //Lägger till hamstrar prioriterat på tid om det finns plats
        public async Task<string> AddToExercise(Hamster h)
        {
            string exercise;

            using (var hdc = HamsterDbContext.CreateDb())
            {
                
                int hamsterInExercise = hdc.Hamsters.Where(x => x.ExerciseAreaId != null).Count();

                if (hamsterInExercise == 0)
                {
                    exercise = $"\nAdding hamsters to exercise:";

                    var gender = hdc.Hamsters.OrderBy(x => x.LatestMotion).Select(x => x.Gender).First();

                    var hamsterGenderWithCage = hdc.Hamsters.Where(x => x.Gender == gender && x.CageId != null && x.ExerciseAreaId == null).OrderBy(x => x.LatestMotion).Take(MaxSize).ToList();

                    var currentTime = HamsterTime.TimeRead();

                    foreach (var hamster in hamsterGenderWithCage)
                    {
                        hamster.ExerciseAreaId = 1;
                        hamster.CageId = null;
                        hamster.LatestMotion = currentTime;
                        hdc.ActivityLogs.Add(new ActivityLog { ActivityId = 4, HamsterId = hamster.Id, TimeStamp = currentTime });

                        exercise += $"\n{h.RecieveHamsterName(hamster.Id)}";

                    }

                    await hdc.SaveChangesAsync();
                    return exercise;
                    
                }
                return "";

            }

        }

        //Tar bort alla hamstrar om villkor uppfylls
        public async Task<string> RemoveFromExercise(DateTime startTime, bool force, Hamster h)
        {
            string tempRemove = "";

            DateTime currentTime = HamsterTime.TimeRead();

            using (var hdc = HamsterDbContext.CreateDb())
            {

                //Tar ett datum om det finns en hamster i exercise annars null
                DateTime? hamsterInExercise = hdc.Hamsters.Where(h => h.ExerciseAreaId != null).Select(x => x.LatestMotion).Take(1).SingleOrDefault();


                //Kollar om det datumet inte är null
                if (hamsterInExercise != null)
                {
                    

                    int validTime = currentTime.Subtract((DateTime)hamsterInExercise).Hours;

                    if (validTime >= 1 || force == true)
                    {
                        tempRemove = $"\nRemoved from exercise:";
                        var hamsterOver60 = hdc.Hamsters.Where(x => x.ExerciseAreaId != null).Select(x => x);

                        foreach (var hamster in hamsterOver60)
                        {

                            hamster.ExerciseAreaId = null;

                            hdc.ActivityLogs.Add(new ActivityLog { ActivityId = 3, HamsterId = hamster.Id, TimeStamp = currentTime });

                            tempRemove += $"\n{h.RecieveHamsterName(hamster.Id)}";
                        }

                        
                        await hdc.SaveChangesAsync();

                        await Cage.ToCage(startTime, h);

                        return tempRemove;

                    }

                }
            }
            return tempRemove;
        }

        public static List<string> HamstersInExercise()
        {
            List<string> hamsterNames = new List<string>();

            using (var hdc = HamsterDbContext.CreateDb())
            {
                var hamstersInExercise = hdc.Hamsters.Where(x => x.ExerciseAreaId != null).Select(x => x.HamsterName);

                foreach (var name in hamstersInExercise)
                {
                    hamsterNames.Add(name);
                }
            }
            return hamsterNames;
        }

    }
}

