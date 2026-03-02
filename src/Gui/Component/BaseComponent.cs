using System.Drawing;

namespace UntitledTycoonGame.Gui.Component;

public abstract class BaseComponent {
    public Color BackgroundColor { get; set; }
    public Color BorderColor { get; set; }
    public int BorderThickness { get; set; }
    public Color ForegroundColor { get; set; }
    public bool IsSelectable { get; set; }
    public bool IsSelected { get; set; }
    public Point Position { get; set; }
    public Color SelectedBackgroundColor { get; set; }
    public Color SelectedBorderColor { get; set; }
    public Color SelectedForegroundColor { get; set; }
    public Size Size { get; set; }

    public int zIndex { get; set; }                      //for drawing multiple components

    public virtual void Render(ConsoleBuffer buffer) {
        buffer.FillRectangle(IsSelected ? SelectedBackgroundColor : BackgroundColor, Position, Size);
        
        for (int i = 0; i < BorderThickness; i++) {
            buffer.DrawRectangle(IsSelected ? SelectedBorderColor : BorderColor,
                new Point(Position.X + 2 * i, Position.Y + i),
                new Size(Size.Width - 4 * i, Size.Height - 2 * i));
        }
    }
    public virtual void HandleKey(ConsoleKeyInfo key) {}
}
