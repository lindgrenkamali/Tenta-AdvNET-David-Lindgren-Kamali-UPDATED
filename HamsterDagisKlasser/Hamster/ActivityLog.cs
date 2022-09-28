using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HamsterDatabaseStructure
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }

        public int? HamsterId { get; set; }
        public virtual Hamster Hamster { get; set; }

        public int? ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public DateTime TimeStamp { get; set; }

        public List<string> EndOfDayResult(Hamster h, DateTime time)
        {
            List<string> hamsterEndOfDay = new List<string>();
            using (var hdc = HamsterDbContext.CreateDb())
            {
                for (int i = 1; i <= 30; i++)
                {
                    var hamsterLogs = hdc.ActivityLogs.Where(x => x.TimeStamp.Year == time.Year && x.TimeStamp.Month == time.Month && x.TimeStamp.Day == time.Day && x.HamsterId == i && x.ActivityId == 4).ToList();

                    var firstMotion = hamsterLogs.Select(x => x.TimeStamp).Min();

                    var name = h.RecieveHamsterName(i);
                    hamsterEndOfDay.Add($"\n\nHamster ID: {i}\nName: {name}\nFirst motion: {firstMotion}\nMinutes until first exercise: {firstMotion.Subtract(time).TotalMinutes}\nTotal exercises today: {hamsterLogs.Count}");
                }
            }
            return hamsterEndOfDay;


        }
    }
}
