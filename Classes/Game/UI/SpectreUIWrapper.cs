using Spectre.Console;

public class SpectreUIWrapper : IGameUi
{
    public string ReadLines()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public void ShowPrompt(Player player)
    {
        AnsiConsole.Markup($"[yellow]{player.Name}[/]> ");
    }

    public void ShowRoom(Room room)
    {
        var panel = new Panel(room.Description!.EscapeMarkup())
            .Header($"[bold]{room.RoomName.EscapeMarkup()}")
            .Border(BoxBorder.Rounded);

        AnsiConsole.Write(panel);

        if (room.ExitsInRoom!.Count > 0)
        {
            var exits = string.Join(", ", room.ExitsInRoom.Keys);
            AnsiConsole.WriteLine($"[grey]Exits: {exits}[/]");
        }
    }

    public void WriteError(string text)
    {
        AnsiConsole.MarkupLine($"[red]{text.EscapeMarkup()}[/]");
    }

    public void WriteInfo(string text)
    {
        AnsiConsole.MarkupLine($"[grey]{text.EscapeMarkup()}[/]");
    }

    public void WriteLine(string text)
    {
        AnsiConsole.MarkupLine(text.EscapeMarkup());
    }
}