using System.ComponentModel.DataAnnotations;
namespace GymAPI.Models
{
    public class Plan
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal MonthlyPrice { get; set; }

        public Plan()
        {
            Name = string.Empty;
        }

        public Plan(string name, decimal monthlyPrice)
        {
            Name = name;
            MonthlyPrice = monthlyPrice;
        }
    }
}