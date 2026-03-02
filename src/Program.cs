using System.Drawing;
using UntitledTycoonGame.Gui;
using UntitledTycoonGame.Gui.Component;
using UntitledTycoonGame.Gui.View;
using Timer = System.Timers.Timer;

namespace UntitledTycoonGame;

public static class Program {
	public static void Main() {
		Console.CursorVisible = false;

		// List<BaseComponent> renderComponents = new();
		//
		// renderComponents.Add(new ValueBar(10, 10, 15, 5, "Test!"));
		// renderComponents.Add(new MainMenuView());

		Timer timer = new Timer();
		timer.Interval = 100;
		timer.AutoReset = true;
		timer.Elapsed += (sender, args) => {ConsoleRenderer.Instance.Render();};
		timer.Start();

		while (true) {
			var key = Console.ReadKey();
			switch (key.Key) {
				case ConsoleKey.F3:
					timer.Stop();
					AnsiTest.Run();
					ConsoleRenderer.Instance.ResetBuffer();
					timer.Start();
					break;
				default:
					ConsoleRenderer.Instance.HandleKey(key);
					break;
			}
		}
	}
}
