using System.Collections.ObjectModel;
using UntitledTycoonGame.Game;

namespace UntitledTycoonGame.ViewModels;

public class LevelSelectMenuViewModel {
    public ObservableCollection<Save.Metadata> SaveMetadata { get; set; } = new(SaveManager.GetSaveMetadata());
}