using UntitledTycoonGame.Gui;
using UntitledTycoonGame.Gui.Component;
using Timer = System.Timers.Timer;

namespace UntitledTycoonGame;

public static class Program {
	public static void Main() {
		Console.CursorVisible = false;

		ConsoleScreen screen = new(new TextComponent());
		Timer timer = new Timer();
		timer.Interval = 50;
		timer.AutoReset = true;
		timer.Elapsed += (sender, args) => screen.Render();
		timer.Start();
		Console.ReadKey();
	}
}