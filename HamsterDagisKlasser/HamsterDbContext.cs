using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HamsterDatabaseStructure
{

    public class HamsterDbContext : DbContext
    {
        public DbSet<Hamster> Hamsters { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityLog> ActivityLogs { get; set; }

        public DbSet<Cage> Cages { get; set; }

        public DbSet<ExerciseArea> ExerciseAreas { get; set; }

        public HamsterDbContext()
        {

        }

        public static HamsterDbContext CreateDb()
        {
            return new HamsterDbContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            try
            {
                optionsbuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=advDavidLindgrenKamali;Trusted_Connection=True; MultipleActiveResultSets=true;");
            }catch
            {
                System.Console.WriteLine("Something wrong with the database");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Owner> ownerList = ReadAll.ReadAllOwners();

            List<Hamster> hamsterList = ReadAll.ReadAllHamsters(ownerList);

            var tempHamsterName = hamsterList.Select(x => x.HamsterName);

            var tempOwnerName = ownerList.Select(x => x.OwnerName);

            modelBuilder.Entity<Owner>().HasData(ownerList.Select(ownerSeed => new Owner

            {
                Id = tempOwnerName.ToList().IndexOf(ownerSeed.OwnerName) + 1,
                OwnerName = ownerSeed.OwnerName

            }
            ));

            modelBuilder.Entity<Hamster>().HasData(hamsterList.Select(hamsterSeed => new Hamster
            {

                Id = tempHamsterName.ToList().IndexOf(hamsterSeed.HamsterName) + 1,
                HamsterName = hamsterSeed.HamsterName,
                Age = hamsterSeed.Age,
                Gender = hamsterSeed.Gender,
                OwnerId = hamsterSeed.OwnerId + 1
            }));


            modelBuilder.Entity<Activity>().HasData(


                new Activity
                {
                    Id = 1,
                    AcivityName = "CheckIn"
                },

                new Activity
                {
                    Id = 2,
                    AcivityName = "CheckOut"
                },

                new Activity
                {
                    Id = 3,
                    AcivityName = "ToCage"
                },

                new Activity
                {
                    Id = 4,
                    AcivityName = "ExerciseArea"

                }


                );

            modelBuilder.Entity<Cage>().HasData(

              new Cage
              {
                  CageID = 1
              },

              new Cage
              {
                  CageID = 2
              },

              new Cage
              {
                  CageID = 3
              },

              new Cage
              {
                  CageID = 4
              },

              new Cage
              {
                  CageID = 5
              },

              new Cage
              {
                  CageID = 6
              },

              new Cage
              {
                  CageID = 7
              },

              new Cage
              {
                  CageID = 8
              },

              new Cage
              {
                  CageID = 9
              },

              new Cage
              {
                  CageID = 10
              }
               );

            modelBuilder.Entity<ExerciseArea>().HasData(

               new ExerciseArea
               {
                   Id = 1
               }
                );

        }
    }
}


