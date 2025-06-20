namespace GymAPI.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }

        public CheckIn(int memberId, DateTime dateTime)
        {
            MemberId = memberId;
            DateTime = dateTime;
        }
        public CheckIn() { }
    }
}