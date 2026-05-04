using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UntitledTycoonGame.Controls;

public partial class RedTitleControl : UserControl {
    public RedTitleControl() {
        InitializeComponent();
    }
    
    public static readonly DirectProperty<RedTitleControl, string> TitleProperty = 
        AvaloniaProperty.RegisterDirect<RedTitleControl, string>(
            nameof(Title), 
            o => o.Title, 
            (o, v) => o.Title = v
        );

    private string title;
    public string Title
    {
        get => title;
        set => SetAndRaise(TitleProperty, ref title, value);
    }
}