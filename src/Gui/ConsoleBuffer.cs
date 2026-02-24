using System.Drawing;

namespace UntitledTycoonGame.Gui;

public class ConsoleBuffer {
    public readonly int Width;
    public readonly int Height;
    public readonly CellData[,] Data;
    
    public ConsoleBuffer(int width, int height) {
        Width = width;
        Height = height;
        Data = new CellData[width, height];
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                Data[x, y].Char = ' ';
                Data[x, y].Foreground = Color.White;
            }
        }
    }

    public void FillRectangle(Color color, Point pos, Size size, bool background) {
        for (int y = pos.Y; y < pos.Y + size.Height && y < Height; y++) {
            for (int x = pos.X; x < pos.X + size.Width && x < Width; x++) {
                if (background) 
                    Data[x, y].Background = color;
                else
                    Data[x, y].Foreground = color;
            }
        }
    }
    
    public void DrawText(string text, Point pos) {
        for (int x = pos.X; x - pos.X < text.Length && x < Width; x++) {
            Data[x, pos.Y].Char = text[x - pos.X];
        }
    }
}
