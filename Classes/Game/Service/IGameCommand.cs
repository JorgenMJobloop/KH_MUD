public interface IGameCommand
{
    // properties
    string Name { get; }
    IReadOnlyList<string> Aliases { get; }
    string Description { get; }
    string Usage { get; }

    /// <summary>
    /// Execute a given command
    /// </summary>
    /// <param name="context">Command context</param>
    /// <returns>execution of a given command</returns>
    CommandResult ExecuteCommand(CommandContext context);
}