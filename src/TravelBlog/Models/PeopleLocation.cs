using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("PeopleLocations")]
    public class PeopleLocation
    {
        [Key]
        public int id { get; set; }

        public int PersonId { get; set; }
        public People People { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
