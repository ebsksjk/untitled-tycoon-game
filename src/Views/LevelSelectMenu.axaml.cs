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
            File.Delete(model.Metadata[GameDataList.SelectedIndex].FilePath);
            model.Metadata.Clear();
            foreach (var data in GameDataManager.GetAllMetadata()) {
                model.Metadata.Add(data);
            }
        }
    }

    private void OnAddButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowLevelCreateMenu();
    private void OnBackButtonClick(object? sender, RoutedEventArgs e) => MainWindow.ShowMainMenu();
}
