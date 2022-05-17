using System.Text.Json;

namespace FilterBox.assets
{
    public class Settings
    {
        public List<Filter> Filters { get; set; }

        public static Settings Configuration;

        public static void LoadSettings()
        {
            using FileStream settingsStream = File.OpenRead("settings.json");
            Configuration = JsonSerializer.Deserialize<Settings>(settingsStream);
        }

        public static void SaveSettings()
        {
            string config = JsonSerializer.Serialize(Configuration);
            File.WriteAllText("settings.json", config);
        }
    }

    public class Filter
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}