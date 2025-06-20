using System.ComponentModel.DataAnnotations;

namespace GymAPI.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public required string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int PlanId { get; set; }

        public Member()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        public Member(string name, string email, DateTime birthDate, int planId)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            PlanId = planId;
        }
    }
}