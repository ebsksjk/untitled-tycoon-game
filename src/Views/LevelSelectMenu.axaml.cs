using Avalonia.Controls;
using Avalonia.Interactivity;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class LevelSelectMenu : UserControl {
    public LevelSelectMenu() {
        InitializeComponent();
    }

    private void OnBackButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new MainMenu() {
            DataContext = new MainMenuViewModel()
        };
    }
}