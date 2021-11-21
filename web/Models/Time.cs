using System;
using System.Collections.Generic;
namespace web.Models
{

    public class Time
    {
        public int TimeID { get; set; }
        public DateTime Arrival {get;set;}
        public DateTime Departure {get;set;}

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}