public class CommandRouter
{
    private readonly CommandRegistry _registry;

    public CommandRouter(CommandRegistry registry)
    {
        _registry = registry;
    }

    public CommandResult Route(string input, Player player, World world, IGameUi ui)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return CommandResult.NOTHANDLED;
        }

        var tokens = Tokenize(input);
        if (tokens.Count == 0)
        {
            return CommandResult.NOTHANDLED;
        }

        var commandName = tokens[0];
        var args = tokens.Count > 1 ? tokens.GetRange(1, tokens.Count - 1) : new List<string>();

        if (!_registry.TryGetCommand(commandName, out var command))
        {
            ui.WriteError($"Unknown command: [{commandName}]");
            return CommandResult.FAILURE;
        }

        var context = new CommandContext(
            input, commandName, args, player, world, ui
        );

        return command!.ExecuteCommand(context);
    }

    // tokenizer (parse & dispatch)
    private static List<string> Tokenize(string input)
    {
        // first, we create a new list of results
        var result = new List<string>();
        // then we create a list of characters to keep track our current character. ex: 'a', 'b'
        var currentChar = new List<char>();
        // and then we create a boolean variable, to see if any of the input as in quotes. ex: hello vs "hello" or 'hello'
        var isInQuotes = false;

        foreach (var character in input.Trim())
        {
            if (character == '"')
            {
                isInQuotes = true;
                continue;
            }

            if (char.IsWhiteSpace(character) && !isInQuotes)
            {
                if (currentChar.Count > 0)
                {
                    result.Add(new string(currentChar.ToArray()));
                    currentChar.Clear();
                }
            }
            else
            {
                currentChar.Add(character);
            }
        }

        if (currentChar.Count > 0)
        {
            result.Add(new string(currentChar.ToArray()));
        }

        return result;
    }
}