using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("People")]
    public class People
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageURL { get; set; }
        public virtual ICollection<PeopleExperience> PeopleExperiences { get; set; }
        public virtual ICollection<PeopleLocation> PeopleLocations { get; set; }

        public override bool Equals(System.Object otherPeople)
        {
            if (!(otherPeople is People))
            {
                return false;
            }
            else
            {
                People newPeople = (People)otherPeople;
                return this.PersonId.Equals(newPeople.PersonId);
            }
        }

        public override int GetHashCode()
        {
            return this.PersonId.GetHashCode();
        }
    }

    
}
