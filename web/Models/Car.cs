using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace web.Models
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarID { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }

        public DateTime? DateCreated {get;set;}

        public DateTime? DateEdited {get;set;}
        

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}