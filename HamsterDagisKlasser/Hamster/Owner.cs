using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HamsterDatabaseStructure
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        public string OwnerName { get; set; }

        public ICollection<Hamster> Hamsters { get; set; }

        public override string ToString()
        {
            return $"{Id}\n {OwnerName}";
        }
    }
}
