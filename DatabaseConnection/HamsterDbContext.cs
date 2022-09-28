using HamsterDayCareClasses;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{

    public class HamsterDbContext : DbContext
    {

        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityLog> ActivityLogs { get; set; }

        public DbSet<Cage> Cages { get; set; }

        public DbSet<ExerciseArea> ExerciseAreas { get; set; }

        public HamsterDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            
            optionsbuilder.UseSqlServer(@"Server=DESKTOP-3C2V0EE\SQLEXPRESS;Database=advDavidLindgrenKamali;Trusted_Connection=True;");
            
        }
    }
}
