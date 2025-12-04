
public class QuitCommand : IGameCommand
{
    public string Name => throw new NotImplementedException();

    public IReadOnlyList<string> Aliases => throw new NotImplementedException();

    public string Description => throw new NotImplementedException();

    public string Usage => throw new NotImplementedException();

    public string ExecuteCommand(string argument, Player player)
    {
        return "[yellow]Exiting game...[/]";
    }

    public string ExecuteCommand(CommandContext context)
    {
        throw new NotImplementedException();
    }
}