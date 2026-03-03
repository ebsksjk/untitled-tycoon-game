using Avalonia.Controls;
using Avalonia.Interactivity;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class MainMenu : UserControl {
    public MainMenu() {
        InitializeComponent();
    }

    private void OnPlayButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new LevelSelectMenu() {
            DataContext = new LevelSelectMenuViewModel()
        };
    }

    private void OnSettingsButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new SettingsMenu() {
            DataContext = new SettingsMenuViewModel()
        };
    }
    
    private void OnCreditsButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new CreditsMenu();
    }
    
    private void OnQuitButtonClick(object sender, RoutedEventArgs e) {
        Environment.Exit(0);
    }
}