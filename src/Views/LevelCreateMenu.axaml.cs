using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using UntitledTycoonGame.Game;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class LevelCreateMenu : UserControl {
    public LevelCreateMenu() {
        InitializeComponent();
        DataContext = new LevelCreateMenuViewModel();
    }

    private void OnCreateButtonClick(object sender, RoutedEventArgs e) {
        if (DataContext is LevelCreateMenuViewModel model) {
            GameDataManager.Create(model.Name, model.FoodExpires);
        }
        MainWindow.ShowLevelSelectMenu();
    }
    
    private void OnCancelButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowLevelSelectMenu();
}