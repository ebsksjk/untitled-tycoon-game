using Avalonia;
using UntitledTycoonGame.src.Game.Simulation;

namespace UntitledTycoonGame;

public static class Program {
	[STAThread]
	public static void Main(string[] args)
	{
		City city = new City(1000);

        BuildAvaloniaApp()
		.StartWithClassicDesktopLifetime(args);
	}
	// Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace();
}
