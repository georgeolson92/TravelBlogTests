using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<PeopleLocation> PeopleLocations { get; set; }
    }
}
