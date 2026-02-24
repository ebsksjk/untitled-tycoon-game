using System.Drawing;

namespace UntitledTycoonGame.Gui.Components;

public abstract class Component {
    public Point Position { get; set; }
    public Size Size { get; set; }
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }

    public int zIndex {get; set;} = 0;                      //for drawing multiple components

    public abstract void Render(ConsoleBuffer buffer);
    public abstract void HandleKey(ConsoleKeyInfo key);
}
