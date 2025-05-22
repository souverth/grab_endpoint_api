using System.Text.Json;

namespace IOT_Server_Endpoint_Grab.Extensions
{
    public class Helper
    {
        private static readonly string LogDirectory = Path.Combine(AppContext.BaseDirectory, "logs", "grab");

        public static void LogRequest(string actionName, object data)
        {
            try
            {
                Directory.CreateDirectory(LogDirectory); // Tạo thư mục nếu chưa có

                var timestamp = DateTime.Now.ToString("yyyyMMddTHHmmssfff"); // Thêm milliseconds tránh trùng
                var fileName = $"{timestamp}_{actionName}.json";
                var filePath = Path.Combine(LogDirectory, fileName);

                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error logging request: {ex.Message}");
            }
        }
    }
}
