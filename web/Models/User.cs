using System;
using System.Collections.Generic;

namespace web.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}