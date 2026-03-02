using System.Drawing;
using UntitledTycoonGame.Gui.Component;

namespace UntitledTycoonGame.Gui.View;

public partial class MainMenuView : MenuPanel {
    public MainMenuView() {
        BorderColor = Color.White;
        BorderThickness = 1;
        Position = new(2, 1);
        
        settingsButton.OnClick += () => ConsoleRenderer.Instance.View = new SettingsView();
        quitButton.OnClick += () => Environment.Exit(0);
        
        Components.Add(gameTitleLabel);
        Components.Add(playButton);
        Components.Add(settingsButton);
        Components.Add(quitButton);
        
        SelectNext();
    }
    
    public override void Render(ConsoleBuffer buffer) {
        Size = new(buffer.Width - 4, buffer.Height - 2);
        gameTitleLabel.Position = new(buffer.Width / 2 - 25, 8);
        playButton.Position = new(buffer.Width / 2 - 15, 15);
        settingsButton.Position = new(buffer.Width / 2 - 15, 19);
        quitButton.Position = new(buffer.Width / 2 - 15, 23);
        
        base.Render(buffer);
        buffer.DrawText("Press F3 to run ANSI test", new(4, buffer.Height - 3));
    }
}