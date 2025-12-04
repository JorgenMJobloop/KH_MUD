public class SayCommand : IGameCommand
{
    public string Name => throw new NotImplementedException();

    public IReadOnlyList<string> Aliases => throw new NotImplementedException();

    public string Description => throw new NotImplementedException();

    public string Usage => throw new NotImplementedException();

    public string ExecuteCommand(string argument, Player player)
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            return "[green]What would you like to say?[/]";
        }
        return $"[green]{player.Name}[/] [blue]says:[/] [green]{argument}[/]";
    }

    public string ExecuteCommand(CommandContext context)
    {
        throw new NotImplementedException();
    }
}