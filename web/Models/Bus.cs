using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace web.Models
{
    public class Bus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusID { get; set; }
        public string BusName{get;set;}
        public int Passengers { get; set; }
        public DateTime? DateCreated {get;set;}

        public DateTime? DateEdited {get;set;}
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}