using System.Text.Json;

namespace UntitledTycoonGame.Game;

public static class SaveManager {
    public static Save? ActiveSavefile { get; set; }

    public static IEnumerable<Save.Level> GetSaveLevels() {
        if (Directory.Exists("./saves")) {
            return Directory.GetDirectories("./saves")
                .Where(x => File.Exists($"{x}/level.json"))
                .Select(x => {
                    try {
                        return JsonSerializer.Deserialize<Save.Level>(File.ReadAllText($"{x}/level.json"));
                    }
                    catch (JsonException e) {
                        return Save.Level.INVALID;
                    }
                });
        }
        return [];
    }

    public static void ReadSavefile(string directory) {
        
    }

    public static void WriteSavefile(string directory) {
        
    }
}
