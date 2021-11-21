namespace web.Models
{

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }

        public int SpotID{get;set;}
        public int TimeID{get;set;}
        public User User { get; set; }
        public Car Car { get; set; }
        public Spot Spot { get; set; }
        public Time Time { get; set; }
    }
}