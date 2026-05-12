namespace UntitledTycoonGame.Game;

public struct GameMetadata {
    public string FilePath { get; set; }
    
    public decimal Balance { get; set; }
    public DateTime GameTime { get; set; }
    public DateTime LastPlayedTime { get; set; }
    public string Name { get; set; }
}