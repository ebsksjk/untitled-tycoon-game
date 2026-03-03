using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace UntitledTycoonGame.Views;

public partial class CreditsMenu : UserControl {
    public CreditsMenu() {
        InitializeComponent();
    }

    private void OnBackButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new MainMenu();
    }
}