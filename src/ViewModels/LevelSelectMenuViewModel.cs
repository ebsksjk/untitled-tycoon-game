using System.Collections.ObjectModel;

namespace UntitledTycoonGame.ViewModels;

public class LevelSelectMenuViewModel {
    public ObservableCollection<string> Items { get; set; } = ["Meow", "Nya", "Mrrp", "Mraow"];
}