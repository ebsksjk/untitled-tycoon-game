namespace UntitledTycoonGame.Gui.Component;

public class Button(string text) : Label(text) {
    public delegate void ClickEventHandler();
    public event ClickEventHandler? OnClick;

    public override void HandleKey(ConsoleKeyInfo key) {
        if (IsSelected && key.Key == ConsoleKey.Enter) OnClick?.Invoke();
    }
}