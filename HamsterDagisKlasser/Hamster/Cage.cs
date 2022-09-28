using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterDatabaseStructure
{
    public class Cage
    {
        [Key]
        [MaxLength(10)]
        public int CageID { get; set; }

        public int MaxSize { get; set; } = 3;

        public ICollection<Hamster> Hamsters { get; set; }


        public static async Task<string> ToCage(DateTime time, Hamster h)
        {

            using (var hdc = HamsterDbContext.CreateDb())
            {

                var hamsterNullCage = (from ha in hdc.Hamsters
                                       where ha.CageId == null && ha.ExerciseAreaId == null
                                       select ha).ToList();

                if (hamsterNullCage.Count == 30)
                {

                    foreach (var hamster in hamsterNullCage)
                    {
                        var cage = (from c in hdc.Cages
                                    where c.Hamsters.Count < c.MaxSize && c.Hamsters.Count > 0 && c.Hamsters.Select(x => x.Gender).First() == hamster.Gender || c.Hamsters.Count == 0
                                    select c.CageID).FirstOrDefault();


                        if (cage != 0)
                        {
                            hamster.CageId = cage;

                            hamster.CheckInTime = time;

                            hdc.ActivityLogs.Add(new ActivityLog { ActivityId = 1, HamsterId = hamster.Id, TimeStamp = time });
                            hdc.ActivityLogs.Add(new ActivityLog { ActivityId = 3, HamsterId = hamster.Id, TimeStamp = time });

                            await hdc.SaveChangesAsync();

                        }

                    };
                    return "Checked in all hamsters";

                }

                else
                {
                    string tempToCage = "Hamsters to cages";

                    foreach (var hamster in hamsterNullCage)
                    {
                        var cage = (from c in hdc.Cages
                                    where c.Hamsters.Count < c.MaxSize && c.Hamsters.Count > 0 && c.Hamsters.Select(x => x.Gender).First() == hamster.Gender || c.Hamsters.Count == 0
                                    select c.CageID).FirstOrDefault();


                        if (cage != 0)
                        {
                            hamster.CageId = cage;

                            hdc.ActivityLogs.Add(new ActivityLog { ActivityId = 3, HamsterId = hamster.Id, TimeStamp = time });

                            tempToCage += $"\n{h.RecieveHamsterName(hamster.Id)}";

                            await hdc.SaveChangesAsync();

                        }

                    };

                    return tempToCage;
                   
                }

            }

        }

        public static List<string> HamstersInCage()
        {
            List<string> hamsterNames = new List<string>();

            using (var hdc = HamsterDbContext.CreateDb())
            {
                var hamstersWithCage = hdc.Hamsters.Where(x => x.CageId != null).Select(x => x.HamsterName);

                foreach (var name in hamstersWithCage)
                {
                    hamsterNames.Add(name);
                }

               
            }
            return hamsterNames;
        }


    }


}