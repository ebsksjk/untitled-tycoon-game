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
        SaveManager.Create(((LevelCreateMenuViewModel)DataContext).SaveName, new Save.Metadata() {
            FoodExpires = ((LevelCreateMenuViewModel)DataContext).FoodExpires
        });
        MainWindow.ShowLevelSelectMenu();
    }
    
    private void OnCancelButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowLevelSelectMenu();
}