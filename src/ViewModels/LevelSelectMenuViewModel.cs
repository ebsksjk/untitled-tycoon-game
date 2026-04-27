using System.Collections.ObjectModel;
using UntitledTycoonGame.Game;

namespace UntitledTycoonGame.ViewModels;

public class LevelSelectMenuViewModel {
    public ObservableCollection<Save.Level> Items { get; set; } = new(SaveManager.GetSaveLevels());
}