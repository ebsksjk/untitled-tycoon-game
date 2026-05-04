using System.Text.Json;

namespace UntitledTycoonGame.Game;

public static class SaveManager {
    public static Save? ActiveSavefile { get; set; }

    public static IEnumerable<Save.Metadata> GetSaveMetadata() {
        if (Directory.Exists("./saves")) {
            return Directory.GetDirectories("./saves")
                .Where(x => File.Exists($"{x}/metadata.json"))
                .Select(x => {
                    try {
                        return JsonSerializer.Deserialize<Save.Metadata>(File.ReadAllText($"{x}/metadata.json"));
                    }
                    catch (JsonException e) {
                        return Save.Metadata.INVALID;
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
