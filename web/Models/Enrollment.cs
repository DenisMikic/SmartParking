namespace web.Models
{

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public int BusID { get; set; }
        public int SpotID{get;set;}     
        public System.DateTime Arrival {get;set;}
        public System.DateTime Departure {get;set;}
        public User User { get; set; }
        public Car Car { get; set; }
        public Bus Bus { get; set; }
        public Spot Spot { get; set; }
    }
}