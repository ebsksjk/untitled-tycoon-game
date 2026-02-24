using System.Drawing;

namespace UntitledTycoonGame.Gui.Components;

public class MainMenuComponent : Component {
    private TextComponent gameTitleText = new() {
        BackgroundColor = Color.DarkBlue,
        Size = new(50, 5),
        Text = "Untitled Tycoon Game v0.1",
    };
    private TextComponent playText = new() {
        BackgroundColor = Color.Blue,
        Size = new(30, 3),
        Text = "Play"
    };
    private TextComponent settingsText = new() {
        BackgroundColor = Color.DarkBlue,
        Size = new(30, 3),
        Text = "Settings"
    };
    private TextComponent quitText = new() {
        BackgroundColor = Color.DarkBlue,
        Size = new(30, 3),
        Text = "Quit"
    };
    
    private int selectedIndex = 0;
    
    public override void Render(ConsoleBuffer buffer) {
        buffer.DrawRectangle(Color.White, new(2, 1), new Point(buffer.Width - 3, buffer.Height - 2));

        gameTitleText.Position = new(buffer.Width / 2 - 25, 8);
        playText.Position = new(buffer.Width / 2 - 15, 15);
        settingsText.Position = new(buffer.Width / 2 - 15, 19);
        quitText.Position = new(buffer.Width / 2 - 15, 23);
        
        gameTitleText.Render(buffer);
        playText.Render(buffer);
        settingsText.Render(buffer);
        quitText.Render(buffer);
        
        buffer.DrawText("Press F3 to run ANSI test", new(4, buffer.Height - 3));
    }

    public override void HandleKey(ConsoleKeyInfo key) {
        switch (key.Key) {
            case ConsoleKey.DownArrow:
                selectedIndex++;
                if(selectedIndex > 2) selectedIndex = 0;
                UpdateColors();
                break;
            case ConsoleKey.UpArrow:
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = 2;
                UpdateColors();
                break;
            case ConsoleKey.Enter:
                if(selectedIndex == 2) Environment.Exit(0);
                break;
        }
    }
    
    private void UpdateColors() {
        playText.BackgroundColor = Color.DarkBlue;
        settingsText.BackgroundColor = Color.DarkBlue;
        quitText.BackgroundColor = Color.DarkBlue;
        
        switch (selectedIndex) {
            case 0: playText.BackgroundColor = Color.Blue; break;
            case 1: settingsText.BackgroundColor = Color.Blue; break;
            case 2: quitText.BackgroundColor = Color.Blue; break;
        }
    }
}