using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public class PeopleExperience
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }
        public People People { get; set; }
        
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
