using UntitledTycoonGame.Gui.Component;

namespace UntitledTycoonGame.Gui.View;

public partial class SettingsView : MenuPanel {
    public SettingsView() {
        Position = new(2, 1);
        
        mainPanel.AddPanel("Test", new Panel());
        mainPanel.AddPanel("Test2", new Panel());
        mainPanel.AddPanel("Test3", new Panel());
    }

    public override void Render(ConsoleBuffer buffer) {
        Size = new(buffer.Width - 4, buffer.Height - 2);
        base.Render(buffer);
        mainPanel.Render(buffer);
    }

    public override void HandleKey(ConsoleKeyInfo key) {
        if (key.Key == ConsoleKey.Escape) {
            ConsoleRenderer.Instance.View = new MainMenuView();
            return;
        }
        mainPanel.HandleKey(key);
    }
}