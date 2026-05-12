using Avalonia.Controls;
using UntitledTycoonGame.Game;
using UntitledTycoonGame.ViewModels;
using UntitledTycoonGame.Views;

namespace UntitledTycoonGame;

public partial class MainWindow : Window {
    public static readonly MainWindow Instance = new() {
        DataContext = new MainMenuViewModel()
    };

    private readonly MainMenu mainMenu;
    private readonly LevelCreateMenu levelCreateMenu;
    private readonly LevelSelectMenu levelSelectMenu;
    private readonly SettingsMenu settingsMenu;
    private readonly CreditsMenu creditsMenu;
    
    private MainWindow() {
        InitializeComponent();
        
        mainMenu = new();
        levelCreateMenu = new();
        levelSelectMenu = new();
        settingsMenu = new();
        creditsMenu = new();
        
        Content = mainMenu;
    }
    
    public static void ShowMainMenu() => Instance.Content = Instance.mainMenu;
    public static void ShowLevelCreateMenu() => Instance.Content = Instance.levelCreateMenu;
    public static void ShowSettingsMenu() =>  Instance.Content = Instance.settingsMenu;
    public static void ShowCreditsMenu() =>  Instance.Content = Instance.creditsMenu;
    
    
    public static void ShowLevelSelectMenu() {
        if (Instance.levelSelectMenu.DataContext is LevelSelectMenuViewModel model) {
            model.Metadata.Clear();
            foreach (var data in GameDataManager.GetAllMetadata()) {
                model.Metadata.Add(data);
            }
        }
        Instance.Content = Instance.levelSelectMenu;
    }
}