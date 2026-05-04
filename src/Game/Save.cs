namespace UntitledTycoonGame.Game;

public struct Save {

    public struct Metadata {
        public static readonly Metadata INVALID = new Metadata() { Name = "INVALID SAVEFILE" };
        
        public decimal Balance { get; set; }
        public DateTime CreatedTime  { get; set; }
        public bool FoodExpires { get; set; }
        public DateTime GameTime { get; set; }
        public DateTime LastPlayedTime { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
    }
}