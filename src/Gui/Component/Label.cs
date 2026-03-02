namespace UntitledTycoonGame.Gui.Component;

public class Label(string text) : BaseComponent {
    public string Text { get; set; } = text;
    public Alignment TextAlignment { get; set; } = Alignment.MiddleCenter;

    public override void Render(ConsoleBuffer buffer) {
        base.Render(buffer);
        
        //TODO: Implement the other alignments, currently only MiddleCenter is supported
        buffer.DrawText(Text, new(Position.X + Size.Width / 2 - Text.Length / 2, Position.Y + Size.Height / 2));
    }

    public override void HandleKey(ConsoleKeyInfo key) {}
}
