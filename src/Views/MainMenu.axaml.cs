using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class MainMenu : UserControl {
    public MainMenu() {
        InitializeComponent();
        DataContext = new MainMenuViewModel();
    }

    private void OnPlayButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowLevelSelectMenu();
    private void OnSettingsButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowSettingsMenu();
    private void OnCreditsButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowCreditsMenu();
    private void OnQuitButtonClick(object? sender, RoutedEventArgs e) => MainWindow.Instance.Close();
}