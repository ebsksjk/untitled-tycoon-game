using System.Drawing;

namespace UntitledTycoonGame.Gui.Components;

public class MainMenuComponent : Component {
    private TextComponent gameTitle = new() {
        BackgroundColor = Color.DarkBlue,
        Size = new(40, 3),
        Text = "Untitled Tycoon Game v0.1",
    };
    
    public override void Render(ConsoleBuffer buffer) {
        buffer.FillColor(Color.White, new(2, 1), new(buffer.Width - 4, 1), true); // Top stripe
        buffer.FillColor(Color.White, new(2, buffer.Height - 2), new(buffer.Width - 4, 1), true); // Bottom stripe
        buffer.FillColor(Color.White, new(2, 2), new(2, buffer.Height - 4), true); // Left stripe
        buffer.FillColor(Color.White, new(buffer.Width - 4, 2), new(2, buffer.Height - 4), true); // Right stripe

        gameTitle.Position = new(buffer.Width / 2 - 20, 8);
        gameTitle.Render(buffer);
    }
}