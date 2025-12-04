
public class LookCommand : IGameCommand
{
    public string Name => throw new NotImplementedException();

    public IReadOnlyList<string> Aliases => throw new NotImplementedException();

    public string Description => throw new NotImplementedException();

    public string Usage => throw new NotImplementedException();

    public string ExecuteCommand(string argument, Player player)
    {
        return "[blue]You look around. It's very quiet and dark..[/]";
    }

    public string ExecuteCommand(CommandContext context)
    {
        throw new NotImplementedException();
    }

    CommandResult IGameCommand.ExecuteCommand(CommandContext context)
    {
        throw new NotImplementedException();
    }
}