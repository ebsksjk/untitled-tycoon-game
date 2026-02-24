using System.Drawing;

namespace UntitledTycoonGame.Gui;

public class ConsoleBuffer {
    public int Width { get; }
    public int Height { get; }
    public CellData[,] Data { get; }
    
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

    public void DrawChar(char c, Point pos) {
        if (IsInBounds(pos)) Data[pos.X, pos.Y].Char = c;
    }
    
    public void DrawText(string text, Point pos) {
        for (int x = pos.X; x - pos.X < text.Length && x < Width; x++) {
            if (IsInBounds(x, pos.Y)) Data[x, pos.Y].Char = text[x - pos.X];
        }
    }

    public void DrawRectangle(Color color, Point pos, Size size) {
        DrawRectangle(color, pos, new Point(pos.X + size.Width - 1, pos.Y + size.Height - 1));
    }

    public void DrawRectangle(Color color, Point topLeft, Point bottomRight) {
        FillRectangle(color, topLeft, new Point(bottomRight.X, topLeft.Y));             // Top line
        FillRectangle(color, topLeft, new Point(topLeft.X + 1, bottomRight.Y));         // Left line
        FillRectangle(color, new Point(bottomRight.X - 1, topLeft.Y), bottomRight);     // Right line
        FillRectangle(color, new Point(topLeft.X, bottomRight.Y), bottomRight);         // Bottom line
    }

    public void FillRectangle(Color color, Point pos, Size size) {
        FillRectangle(color, pos, new Point(pos.X + size.Width - 1, pos.Y + size.Height - 1));
    }

    public void FillRectangle(Color color, Point topLeft, Point bottomRight) {
        for (int y = topLeft.Y; y <= bottomRight.Y && y < Height; y++) {
            for (int x = topLeft.X; x <= bottomRight.X && x < Width; x++) {
                if (IsInBounds(x, y)) Data[x, y].Background = color;
            }
        }
    }

    private bool IsInBounds(Point pos) {
        return IsInBounds(pos.X, pos.Y);
    }

    private bool IsInBounds(int x, int y) {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
