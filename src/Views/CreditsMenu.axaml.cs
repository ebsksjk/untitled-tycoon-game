using Avalonia.Controls;
using Avalonia.Interactivity;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class CreditsMenu : UserControl {
    public CreditsMenu() {
        InitializeComponent();
    }

    private void OnBackButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowMainMenu();
}