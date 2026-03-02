namespace UntitledTycoonGame.Gui.Component;

public class Panel : BaseComponent {
    public List<BaseComponent> Components { get; } = [];

    public override void Render(ConsoleBuffer buffer) {
        base.Render(buffer);
        foreach(BaseComponent c in Components) {
            c.Render(buffer);
        }
    }
    
    public override void HandleKey(ConsoleKeyInfo key) {
        foreach (BaseComponent c in Components) {
            c.HandleKey(key);
        }
    }
}