using Avalonia.Controls;
using Avalonia.Interactivity;
using UntitledTycoonGame.Game;
using UntitledTycoonGame.ViewModels;

namespace UntitledTycoonGame.Views;

public partial class LevelSelectMenu : UserControl {
    public LevelSelectMenu() {
        InitializeComponent();
        DataContext = new LevelSelectMenuViewModel();
    }

    public void SetLevelDisplay() {
        
    }

    private void OnDeleteButtonClick(object? sender, RoutedEventArgs e) {
        if (DataContext is LevelSelectMenuViewModel model && GameDataList.SelectedIndex >= 0) {
            model.GameDataFiles[GameDataList.SelectedIndex].File.Delete();
            model.GameDataFiles.Clear();
            foreach (var data in SaveManager.GetGameDataFiles()) {
                model.GameDataFiles.Add(data);
            }
        }
    }

    private void OnAddButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowLevelCreateMenu();
    private void OnBackButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowMainMenu();
}