using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Spot
    {
        public int SpotID { get; set; }
        public int SpotNumber {get;set;}
        public string SpotName {get;set;}

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}