namespace UntitledTycoonGame.Gui.Component;

public class MenuPanel : Panel {
    protected ConsoleKey nextKey = ConsoleKey.DownArrow;
    protected ConsoleKey prevKey = ConsoleKey.UpArrow;
    
    protected void Deselect() {
        foreach (BaseComponent c in Components) {
            c.IsSelected = false;
        }
    }
    
    protected void SelectNext() {
        int current = Components.FindIndex(x => x.IsSelected);
        int next = Components.FindIndex(current + 1, x => x.IsSelectable);
        if (next >= 0) {
            Deselect();
            Components[next].IsSelected = true;
        }
    }
    
    protected void SelectPrevious() {
        int current = Components.FindIndex(x => x.IsSelected);
        int previous = Components.FindIndex(current - 1, x => x.IsSelectable);
        if (previous >= 0) {
            Deselect();
            Components[previous].IsSelected = true;
        }
    }

    public override void HandleKey(ConsoleKeyInfo key) {
        if (key.Key == nextKey) {
            SelectNext();
        } else if (key.Key == prevKey) {
            SelectPrevious();
        }
        base.HandleKey(key);
    }
}