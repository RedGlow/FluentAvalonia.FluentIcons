using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using FluentAvalonia.FluentIcons.Helpers;

namespace FluentAvalonia.FluentIcons;

[Obsolete("Use FluentIcon instead. This will be removed when FluentAvalonia 2.0 is released.")]
public class RegularFluentIcon : PathIcon
{
    public static readonly StyledProperty<RegularFluentIconSymbol> IconProperty =
        AvaloniaProperty.Register<RegularFluentIcon, RegularFluentIconSymbol>(nameof(Icon));

    public RegularFluentIconSymbol Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IconProperty)
        {
            var font = IconHelper.RegularFont;
            Data = PathGeometry.Parse(font.GetGlyphPath(font.GetGlyph((int)Icon)).ToSvgPathData());
        }
    }
}