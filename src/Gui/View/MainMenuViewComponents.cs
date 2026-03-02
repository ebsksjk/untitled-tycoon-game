using System.Drawing;
using UntitledTycoonGame.Gui.Component;

namespace UntitledTycoonGame.Gui.View;

public partial class MainMenuView {
    private readonly Label gameTitleLabel = new("Untitled Tycoon Game v0.1") {
        BackgroundColor = Color.DarkBlue,
        IsSelectable = false,
        Size = new(50, 5)
    };
    private readonly Button playButton = new("Play") {
        BackgroundColor = Color.DarkBlue,
        IsSelectable = true,
        SelectedBackgroundColor = Color.Blue,
        Size = new(30, 3)
    };
    private readonly Button settingsButton = new("Settings") {
        BackgroundColor = Color.DarkBlue,
        IsSelectable = true,
        SelectedBackgroundColor = Color.Blue,
        Size = new(30, 3)
    };
    private readonly Button quitButton = new("Quit") {
        BackgroundColor = Color.DarkBlue,
        IsSelectable = true,
        SelectedBackgroundColor = Color.Blue,
        Size = new(30, 3)
    };
}