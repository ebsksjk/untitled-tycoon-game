using Avalonia.Controls;
using UntitledTycoonGame.ViewModels;
using UntitledTycoonGame.Views;

namespace UntitledTycoonGame;

public partial class MainWindow : Window {
    public static readonly MainWindow Instance = new() {
        DataContext = new MainMenuViewModel()
    };

    private readonly MainMenu mainMenu;
    private readonly LevelSelectMenu levelSelectMenu;
    private readonly SettingsMenu settingsMenu;
    private readonly CreditsMenu creditsMenu;
    
    private MainWindow() {
        InitializeComponent();
        
        mainMenu = new();
        levelSelectMenu = new();
        settingsMenu = new();
        creditsMenu = new();
        
        Content = mainMenu;
    }
    
    public static void ShowMainMenu() => Instance.Content = Instance.mainMenu;
    public static void ShowLevelSelectMenu() => Instance.Content = Instance.levelSelectMenu;
    public static void ShowSettingsMenu() =>  Instance.Content = Instance.settingsMenu;
    public static void ShowCreditsMenu() =>  Instance.Content = Instance.creditsMenu;
}