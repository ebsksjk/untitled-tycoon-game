using Avalonia.Controls;
using Avalonia.Interactivity;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class SettingsMenu : UserControl {
    public SettingsMenu() {
        InitializeComponent();
        DataContext = new SettingsMenuViewModel();
    }
    
    private void OnBackButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowMainMenu();
}