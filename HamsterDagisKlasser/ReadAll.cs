using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HamsterDatabaseStructure
{
    public class ReadAll
    {
        public static List<Owner> ReadAllOwners()
        {

            List<Owner> ownerList = new List<Owner>();
            string path = Directory.GetCurrentDirectory();


            path = Path.GetFullPath(Path.Combine(path, @"..\"));

            if(File.Exists(path + "Hamsterlista30.csv"))
            {
                path += "Hamsterlista30.csv";
            }

            else
            {
                path += @"..\..\..\" + "Hamsterlista30.csv";
            }
           

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var owner = reader.ReadLine();

                    var splitOwner = owner.Split(';');

                    Owner tempOwner = new Owner
                    {
                        OwnerName = splitOwner[3]
                    };


                    if (!ownerList.Any(x => x.OwnerName == splitOwner[3]))
                    {
                        ownerList.Add(tempOwner);
                    }
                }
            }

            return ownerList;
        }


        public static List<Hamster> ReadAllHamsters(List<Owner> ownerList)
        {
            List<Hamster> hamsterList = new List<Hamster>();

            var ownerListNames = ownerList.Select(x => x.OwnerName);

            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\"));

            if (File.Exists(path + "Hamsterlista30.csv"))
            {
                path += "Hamsterlista30.csv";
            }

            else
            {
                path += @"..\..\..\" + "Hamsterlista30.csv";
            }

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var hamster = reader.ReadLine();
                    var splitHamster = hamster.Split(';');

                    Hamster tempHamster = new Hamster
                    {
                        HamsterName = splitHamster[0],
                        Age = int.Parse(splitHamster[1]),
                        Gender = splitHamster[2],
                        OwnerId = ownerListNames.ToList().IndexOf(splitHamster[3])
                    };

                    hamsterList.Add(tempHamster);
                }

            }
            return hamsterList;
        }
    }


}