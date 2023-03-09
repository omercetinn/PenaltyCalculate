namespace PenaltyCalculate.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        public int WorkDayNumber { get; set; }
        public int PenaltyMoney { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public bool Status { get; set; }
        public int DelayedTime { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}