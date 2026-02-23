using System.Drawing;

namespace UntitledTycoonGame.Gui;

public struct ConsoleBuffer {
    public int Width;
    public int Height;
    public Color[,] FgColorData;
    public Color[,] BgColorData;
    public char[,] CharData;
    
    public ConsoleBuffer(int width, int height) {
        Width = width;
        Height = height;
        FgColorData = new Color[width, height];
        BgColorData = new Color[width, height];
        CharData = new char[width, height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                FgColorData[x, y] = Color.White;
                BgColorData[x, y] = Color.DarkBlue;
                CharData[x, y] = ' ';
            }
        }
    }
    
    public void DrawText(string text, int x, int y, Color fg, Color bg) {
        for (int cx = x; cx - x < text.Length && cx < Width; cx++) {
            FgColorData[cx, y] = fg;
            BgColorData[cx, y] = bg;
            CharData[cx, y] = text[cx - x];
        }
    }
}