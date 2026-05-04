using Avalonia.Controls;
using Avalonia.Interactivity;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class LevelSelectMenu : UserControl {
    public LevelSelectMenu() {
        InitializeComponent();
        DataContext = new LevelSelectMenuViewModel();
    }

    private void OnBackButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowMainMenu();
}