public class CommandContext
{
    // Command handling & user input handling
    public string? RawInput { get; }
    public string? CommandName { get; }
    public IReadOnlyList<string>? Arguments { get; }

    // Player & game world context
    public Player? Player { get; }
    public World? World { get; }
    public IGameUi? Ui { get; }

    // primary constructor
    public CommandContext(string rawInput, string commandName, IReadOnlyList<string> arguments, Player player, World world, IGameUi ui)
    {
        RawInput = rawInput;
        CommandName = commandName;
        Arguments = arguments;
        Player = player;
        World = world;
        Ui = ui;
    }
}