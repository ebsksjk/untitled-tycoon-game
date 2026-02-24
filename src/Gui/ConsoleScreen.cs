using System.Diagnostics;
using System.Drawing;
using System.Text;
using UntitledTycoonGame.Gui.Components;

namespace UntitledTycoonGame.Gui;

public class ConsoleScreen {
    private List<Component> components;
    private long renderTime = -1;

    public ConsoleScreen(List<Component> components) {
        this.components = components;
    }
    
    public void Render() {
        Stopwatch sw = new();
        sw.Start();
        
        ConsoleBuffer buffer = new ConsoleBuffer(Console.BufferWidth, Console.BufferHeight);
        foreach(Component comp in components){
            comp.Render(buffer);
        }

        
        StringBuilder sb = new();
        Color? lastFg = null;
        Color? lastBg = null;
        
        for (int y = 0; y < buffer.Height; y++) {
            for (int x = 0; x < buffer.Width; x++) {
                Color fg = buffer.FgColorData[x, y];
                Color bg = buffer.BgColorData[x, y];
                if (fg != lastFg || bg != lastBg || x == 0) {
                    lastFg = fg;
                    lastBg = bg;
                    sb.Append($"\e[38;2;{fg.R};{fg.G};{fg.B};48;2;{bg.R};{bg.G};{bg.B}m");
                }
                sb.Append(buffer.CharData[x, y]);
            }
            if (y < buffer.Height - 1) {
                sb.Append("\e[m\n");
            }
        }
        
        Console.Clear();
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
