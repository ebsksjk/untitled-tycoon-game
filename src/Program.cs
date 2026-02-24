using System.Drawing;
using UntitledTycoonGame.Gui;
using UntitledTycoonGame.Gui.Components;
using Timer = System.Timers.Timer;
using UntitledTycoonGame.Logic;

namespace UntitledTycoonGame;

public static class Program {
	public static void Main() {
		Console.CursorVisible = false;

		List<Component> renderComponents = new();

		renderComponents.Add(new ValueBar(10, 10, 15, 5, "Test!"));
		renderComponents.Add(new MainMenuComponent());

		ConsoleScreen screen = new(renderComponents);
		Timer timer = new Timer();
		timer.Interval = 100;
		timer.AutoReset = true;
		timer.Elapsed += (sender, args) => {screen.Render();};
		timer.Start();

		while (true) {
			var key = Console.ReadKey();
			switch (key.Key) {
				case ConsoleKey.F3:
					timer.Stop();
					AnsiTest.Run();
					screen.ResetBuffer();
					timer.Start();
					break;
				default:
					screen.HandleKey(key);
					break;
			}
		}
	}
}
