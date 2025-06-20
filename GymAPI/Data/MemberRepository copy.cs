using GymAPI.Models;
using System.Text.Json;

namespace GymAPI.Data
{
    public class MemberRepository
    {
        private const string FilePath = "members.json";

        public static List<Member> LoadMembers()
        {
            if (!File.Exists(FilePath))
                File.WriteAllText(FilePath, "[]");

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
        }

        public static void SaveMembers(List<Member> members)
        {
            string json = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}