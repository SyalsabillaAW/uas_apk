using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace uas_apk.Data
{
    public static class DataService
    {
        private static string GetFilePath(string fileName)
        {
            return Path.Combine(FileSystem.AppDataDirectory, fileName);
        }

        public static async Task SaveToJsonAsync<T>(T data, string fileName)
        {
            var filePath = GetFilePath(fileName);
            var jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public static async Task<T> LoadFromJsonAsync<T>(string fileName) where T : new()
        {
            var filePath = GetFilePath(fileName);

            if (!File.Exists(filePath))
            {
                return new T(); 
            }

            var jsonString = await File.ReadAllTextAsync(filePath);
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return new T(); 
            }

            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
