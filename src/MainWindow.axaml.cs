using Avalonia.Controls;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class MainWindow : Window {
    public static readonly MainWindow Instance = new() {
        DataContext = new MainMenuViewModel()
    };
    
    private MainWindow() {
        InitializeComponent();
        Content = new MainMenu() {
            DataContext = new MainMenuViewModel()
        };
    }
}