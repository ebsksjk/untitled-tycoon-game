using System.Drawing;

namespace UntitledTycoonGame.Gui;

public class ConsoleBuffer {
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
                BgColorData[x, y] = Color.Black;
                CharData[x, y] = ' ';
            }
        }
    }

    public void FillColor(Color color, Point pos, Size size, bool background) {
        for (int y = pos.Y; y < pos.Y + size.Height && y < Height; y++) {
            for (int x = pos.X; x < pos.X + size.Width && x < Width; x++) {
                if (background) 
                    BgColorData[x, y] = color;
                else
                    FgColorData[x, y] = color;
            }
        }
    }
    
    public void DrawText(string text, Point pos) {
        for (int x = pos.X; x - pos.X < text.Length && x < Width; x++) {
            CharData[x, pos.Y] = text[x - pos.X];
        }
    }
}
