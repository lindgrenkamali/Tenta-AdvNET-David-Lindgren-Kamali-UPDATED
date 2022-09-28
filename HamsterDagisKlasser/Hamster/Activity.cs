using System.ComponentModel.DataAnnotations;

namespace HamsterDatabaseStructure
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        public string AcivityName { get; set; }
    }
}
