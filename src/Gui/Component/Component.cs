namespace UntitledTycoonGame.Gui.Component;

public abstract class Component {
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public abstract void Render(ConsoleBuffer buffer);
}