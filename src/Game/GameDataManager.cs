using System.Text.Json;

namespace UntitledTycoonGame.Game;

public static class GameDataManager {
    private static readonly string SaveDir = "./saves/";

    public static void Create(string name, bool foodExpires) {
        Directory.CreateDirectory(SaveDir);
        GameData newData = new GameData(name, foodExpires);

        using FileStream fs = File.Create($"{SaveDir}{name}.json");
        JsonSerializer.Serialize(fs, newData);
    }
    
    public static IEnumerable<GameMetadata> GetAllMetadata() {
        Directory.CreateDirectory(SaveDir);
        return Directory.GetFiles(SaveDir)
            .Where(x => x.EndsWith(".json"))
            .Select(x => {
                try {
                    var data = JsonSerializer.Deserialize<GameData>(File.ReadAllText(x));
                    return new GameMetadata() {
                        FilePath = x,
                        Balance = data.Balance,
                        GameTime = data.GameTime,
                        LastPlayedTime = data.LastPlayedTime,
                        Name = data.Name
                    };
                }
                catch (JsonException e) {
                    return new GameMetadata();
                }
            });
    }
    
    public static GameData LoadGame(string fileName) {
        using FileStream fs = File.OpenRead($"{SaveDir}{fileName}.json");
        return JsonSerializer.Deserialize<GameData>(fs);
    }

    public static void SaveGame(GameData data) {
        using FileStream fs = File.Create($"{SaveDir}{data.Name}.json");
        JsonSerializer.Serialize(fs, data);
    }
}
