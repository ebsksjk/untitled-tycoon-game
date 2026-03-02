using System.Drawing;

namespace UntitledTycoonGame.Gui.Component;

public class TabPanel : MenuPanel {
    private Panel? activePanel;

    public TabPanel() {
        nextKey = ConsoleKey.RightArrow;
        prevKey = ConsoleKey.LeftArrow;
    }

    public void AddPanel(string title, Panel panel) {
        Button btn = new(title) {
            BackgroundColor = Color.FromArgb(30, 30, 30),
            Position = new Point(Position.X + Components.Select(x => x.Size.Width).Sum(), Position.Y),
            SelectedBackgroundColor = Color.FromArgb(60, 60, 60),
            Size = new(Math.Max(title.Length + 4, 24), 5)
        };
        btn.OnClick += () => { activePanel = panel; };
        Components.Add(btn);
        activePanel ??= panel;
    }

    public override void Render(ConsoleBuffer buffer) {
        base.Render(buffer);

        if (activePanel != null) {
            activePanel.Position = new(Position.X, Position.Y + 4);
            activePanel.Size = new(Size.Width, Size.Height - 4);
            activePanel.Render(buffer);
        }
    }
}