// See https://aka.ms/new-console-template for more information

using FluentAvalonia.FluentIcons;
using FluentAvalonia.FluentIcons.Helpers;

void Error(string error, int errorCode)
{
    Console.WriteLine(error);
    Environment.Exit(errorCode);
}

Console.WriteLine("Write the name of the icon you want to extract. You can find the icons here (must convert from kebab-case to pascal-case) https://icon-sets.iconify.design/fluent/folder-48-regular/");
var line = Console.ReadLine()?.Trim();
if (string.IsNullOrEmpty(line))
{
    Error("Must enter an icon name", 1);
}

if (!Enum.TryParse<FluentIconSymbol>(line, out var fluentIconSymbol))
{
    Error("Cannot find the symbol", 2);
}

var svgPathData = IconHelper.GetSvgPathDataFromIcon(fluentIconSymbol);

Console.WriteLine("\nAdd this to a global resource dictionary:");
Console.WriteLine($"<PathGeometry x:Key=\"{line}\">{svgPathData}</PathGeometry>");
Console.WriteLine("\nThen, you can use it like:");
Console.WriteLine($"<PathIcon Height=\"16\" Width=\"16\" Foreground=\"Black\" Data=\"{{StaticResource {line}}}\" />");