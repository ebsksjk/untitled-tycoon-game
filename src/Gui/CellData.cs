using System.Drawing;

namespace UntitledTycoonGame.Gui;

public struct CellData : IEquatable<CellData> {
    public char Char;
    public Color Background;
    public Color Foreground;

    public static bool operator ==(CellData a, CellData b) {
        return a.Char == b.Char && a.Background == b.Background && a.Foreground == b.Foreground;
    }
    public static bool operator !=(CellData a, CellData b) {
        return !(a == b);
    }

    public bool Equals(CellData other) {
        return Char == other.Char && Background.Equals(other.Background) && Foreground.Equals(other.Foreground);
    }

    public override bool Equals(object? obj) {
        return obj is CellData other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Char, Background, Foreground);
    }
}