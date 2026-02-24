using System.Diagnostics;
using System.Drawing;
using System.Text;
using UntitledTycoonGame.Gui.Components;

namespace UntitledTycoonGame.Gui;

public class ConsoleScreen {
    private ConsoleBuffer lastBuffer = new(0, 0);
    private List<Component> components;
    private long renderTime = -1;

    public ConsoleScreen(List<Component> components) {
        this.components = components;
    }
    
    public void Render() {
        Stopwatch sw = new();
        sw.Start();
        
        ConsoleBuffer buffer = new ConsoleBuffer(Console.BufferWidth, Console.BufferHeight);
        buffer.DrawText($"ms/frame: {renderTime}", new(0, 0));
        foreach(Component comp in components){
            comp.Render(buffer);
        }

        
        StringBuilder sb = new();
        Color? lastFg = null;
        Color? lastBg = null;
        bool ansiJumpRequired = true;
        for (int y = 0; y < buffer.Height; y++) {
            ansiJumpRequired = true;
            for (int x = 0; x < buffer.Width; x++) {
                // Check if this pixel/char has changed at all from last frame
                if (lastBuffer.Width == buffer.Width && lastBuffer.Height == buffer.Height
                    && lastBuffer.Data[x, y] == buffer.Data[x, y]) {
                    ansiJumpRequired = true;
                    continue;
                }

                if (ansiJumpRequired) {
                    sb.Append($"\e[{y + 1};{x + 1}H");
                    ansiJumpRequired = false;
                }
                Color fg = buffer.Data[x, y].Foreground;
                Color bg = buffer.Data[x, y].Background;
                if (fg != lastFg || bg != lastBg) {
                    lastFg = fg;
                    lastBg = bg;
                    sb.Append($"\e[38;2;{fg.R};{fg.G};{fg.B};48;2;{bg.R};{bg.G};{bg.B}m");
                }
                sb.Append(buffer.Data[x, y].Char);
            }
        }
        
        lastBuffer = buffer;
        
        Console.Write(sb.ToString());
        sw.Stop();
        renderTime = sw.ElapsedMilliseconds;
    }

    public void HandleKey(ConsoleKeyInfo keyInfo) {
        //TODO: handle key per component seperately?
        foreach(Component comp in components){
            comp.HandleKey(keyInfo);
        }

    }
}
