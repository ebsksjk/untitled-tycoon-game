namespace UntitledTycoonGame.Game;

public struct GameData(string? name, bool foodExpires) {
    #region Metadata
    public decimal Balance { get; set; } = 10000;
    public DateTime CreatedTime  { get; set; } = DateTime.Now;
    public bool FoodExpires { get; set; } = foodExpires;
    public DateTime GameTime { get; set; } = new DateTime(2024, 1, 1, 7, 0, 0);
    public DateTime LastPlayedTime { get; set; } = DateTime.Now;
    public string Name { get; set; } = name ?? "Untitled Supermarket";
    public double Rating { get; set; } = 0;
    #endregion
}