using GymAPI.Models;
using System.Text.Json;

namespace GymAPI.Data
{
    public class PlanRepository
    {
        private const string FilePath = "plans.json";

        public static List<Plan> LoadPlans()
        {
            if (!File.Exists(FilePath))
                File.WriteAllText(FilePath, "[]");

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Plan>>(json) ?? new List<Plan>();
        }

        public static void SavePlans(List<Plan> plans)
        {
            string json = JsonSerializer.Serialize(plans, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
