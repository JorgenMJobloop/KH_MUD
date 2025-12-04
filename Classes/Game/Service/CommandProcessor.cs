public class CommandProcessor
{
    /// <summary>
    /// a key-value pairing of a set of commands(string) and the command to execute(seperate command class. ex: LookCommand)
    /// </summary>
    private readonly Dictionary<string, IGameCommand>? _commands;

    public CommandProcessor()
    {
        // we initalize our _commands Dictionary, and give it keys that correspond with our currently created commands
        _commands = new Dictionary<string, IGameCommand>(StringComparer.OrdinalIgnoreCase)
        {
            {"look", new LookCommand()},
            {"say", new SayCommand()},
            {"quit", new QuitCommand()}
        };
    }

    /// <summary>
    /// Process any command avaiable, defined by user input
    /// </summary>
    /// <param name="input">the user input</param>
    /// <param name="player">the player currently playing</param>
    /// <returns>a string representation of the current command being processed</returns>
    public string ProcessCommand(string input, Player player)
    {
        var parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        var cmd = parts[0];
        var args = parts.Length > 1 ? parts[1] : string.Empty;

        if (_commands!.TryGetValue(cmd, out var command))
        {
            return "";
        }
        return "[red]Unknown command[/]";
    }
}