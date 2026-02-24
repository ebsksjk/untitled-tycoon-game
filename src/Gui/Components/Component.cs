using System.Drawing;

namespace UntitledTycoonGame.Gui.Components;

public abstract class Component {
    public Point Position { get; set; }
    public Size Size { get; set; }
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }

    public abstract void Render(ConsoleBuffer buffer);
}