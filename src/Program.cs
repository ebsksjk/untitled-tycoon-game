using System.Drawing;
using UntitledTycoonGame.Gui;
using UntitledTycoonGame.Gui.Component;
using UntitledTycoonGame.Gui.View;
using Timer = System.Timers.Timer;
using UntitledTycoonGame.Logic;

namespace UntitledTycoonGame;

public static class Program {
	public static void Main() {
		Console.CursorVisible = false;

		List<BaseComponent> renderComponents = new();

		renderComponents.Add(new ValueBar(10, 10, 15, 5, "Test!"));
		renderComponents.Add(new MainMenuView());

		ConsoleRenderer renderer = new(renderComponents);
		Timer timer = new Timer();
		timer.Interval = 100;
		timer.AutoReset = true;
		timer.Elapsed += (sender, args) => {renderer.Render();};
		timer.Start();

		while (true) {
			var key = Console.ReadKey();
			switch (key.Key) {
				case ConsoleKey.F3:
					timer.Stop();
					AnsiTest.Run();
					renderer.ResetBuffer();
					timer.Start();
					break;
				default:
					renderer.HandleKey(key);
					break;
			}
		}
	}
}
