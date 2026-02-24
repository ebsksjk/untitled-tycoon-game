using System.Drawing;
using UntitledTycoonGame.Gui;
using UntitledTycoonGame.Gui.Components;
using Timer = System.Timers.Timer;

namespace UntitledTycoonGame;

public static class Program {
	public static void Main() {
		Console.CursorVisible = false;
		
		ConsoleScreen screen = new(new MainMenuComponent());
		Timer timer = new Timer();
		timer.Interval = 50;
		timer.AutoReset = true;
		timer.Elapsed += (sender, args) => screen.Render();
		timer.Start();

		while (true) {
			var key = Console.ReadKey();
			switch (key.Key) {
				case ConsoleKey.F3:
					timer.Stop();
					Console.Clear();
					AnsiTest.Run();
					Console.ReadKey();
					timer.Start();
					break;
				default:
					screen.HandleKey(key);
					break;
			}
		}
	}
}