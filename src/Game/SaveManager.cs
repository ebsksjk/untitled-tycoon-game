using System.Text.Json;

namespace UntitledTycoonGame.Game;

public static class SaveManager {
    public static GameData? ActiveSavefile { get; set; }

    public static IEnumerable<GameDataFile> GetGameDataFiles() {
        Directory.CreateDirectory("./saves/");
        return Directory.GetFiles("./saves/")
            .Where(x => x.EndsWith(".json"))
            .Select(x => {
                try {
                    return new GameDataFile() {
                        File = new FileInfo(x),
                        GameData = JsonSerializer.Deserialize<GameData>(File.ReadAllText(x))
                    };
                }
                catch (JsonException e) {
                    return new GameDataFile();
                }
            });
    }

    public static void Create(string? name, bool foodExpires) {
        Directory.CreateDirectory($"./saves/");
        GameData newData = new GameData(name, foodExpires);

        string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        using (FileStream fs = File.Create($"./saves/{fileName}.json")) {
            JsonSerializer.Serialize(fs, newData);
        }
    }

    public static void ReadSavefile(string directory) {
        
    }

    public static void WriteSavefile(string directory) {
        
    }
}
