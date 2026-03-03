using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class CreditsMenu : UserControl {
    public CreditsMenu() {
        InitializeComponent();
    }

    private void OnBackButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new MainMenu() {
            DataContext = new MainMenuViewModel()
        };
    }
}