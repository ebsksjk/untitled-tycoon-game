namespace UntitledTycoonGame.Gui.Components;

public class TextComponent : Component {
    public string Text { get; set; } = "";
    public Alignment TextAlignment { get; set; } = Alignment.MiddleCenter;
    
    public override void Render(ConsoleBuffer buffer) {
        buffer.FillColor(BackgroundColor, Position, Size, true);
        
        //TODO: Implement the other alignments, currently only MiddleCenter is supported
        buffer.DrawText(Text, new(Position.X + Size.Width / 2 - Text.Length / 2, Position.Y + Size.Height / 2));
    }

    public override void HandleKey(ConsoleKeyInfo key) {
        throw new NotImplementedException();
    }
}
