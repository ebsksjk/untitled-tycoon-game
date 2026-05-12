using System.Collections.ObjectModel;
using UntitledTycoonGame.Game;

namespace UntitledTycoonGame.ViewModels;

public class LevelSelectMenuViewModel {
    public ObservableCollection<GameMetadata> Metadata { get; set; } = new();
}