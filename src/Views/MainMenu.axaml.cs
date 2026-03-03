using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class MainMenu : UserControl {
    public MainMenu() {
        InitializeComponent();
    }
    
    private void OnCreditsButtonClick(object? sender, RoutedEventArgs e) {
        MainWindow.Instance.Content = new CreditsMenu() {
            DataContext = new CreditsWindowViewModel()
        };
    }
    
    private void OnQuitButtonClick(object sender, RoutedEventArgs e) {
        Environment.Exit(0);
    }
}