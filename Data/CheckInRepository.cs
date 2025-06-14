using GymAPI.Models;
using System.Text.Json;

namespace GymAPI.Data
{
    public class CheckInRepository
    {
        private const string FilePath = "checkins.json";

        public static List<CheckIn> LoadCheckIns()
        {
            if (!File.Exists(FilePath))
                File.WriteAllText(FilePath, "[]");

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<CheckIn>>(json) ?? new List<CheckIn>();
        }

        public static void SaveCheckIns(List<CheckIn> checkIns)
        {
            string json = JsonSerializer.Serialize(checkIns, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
