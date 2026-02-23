using System.Text;

namespace UntitledTycoonGame.Gui;

/**
 * Writes formatted and colored text to stdout. The only purpose of this class is testing whether the console used
 * by the IDE properly shows ANSI-escaped formatting.
 */
public static class AnsiTest {
    public static void Run() {
        StringBuilder sb = new();
        sb.Append("ANSI Test\n\n");
        sb.Append("\e[mnormal ");
        sb.Append("\e[3mitalic\e[m ");
        sb.Append("\e[4munderline\e[m ");
        sb.Append("\e[5mblink\e[m ");
        sb.Append("\e[9mstrikethrough\e[m\n\n");

        sb.Append("3bit color\n");
        for (int fg = 30; fg < 38; fg++) {
            for (int bg = 40; bg < 48; bg++) {
                sb.Append($"\e[{bg};{fg}m #");
            }
            sb.Append("\e[m\n");
        }

        sb.Append("\n8bit color\n");
        for (int color = 0; color < 256; color++) {
            sb.Append($"\e[48;5;{color}m  ");
            if (color == 15 || (color - 15) % 36 == 0) {
                sb.Append("\e[m\n");
            }
        }

        sb.Append("\e[m\n\n24bit color\n");
        for (int blue = 0; blue < 32; blue++) {
            for (int green = 0; green < 32; green++) {
                sb.Append($"\e[48;2;255;{8*green};{8*blue}m  ");
            }
            sb.Append("\e[m\n");
        }
        
        Console.WriteLine(sb.ToString());
    }
}