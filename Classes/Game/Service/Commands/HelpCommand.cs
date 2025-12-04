using System.Text;

public class HelpCommand : IGameCommand
{
    private readonly CommandRegistry _registry;

    public HelpCommand(CommandRegistry registry)
    {
        _registry = registry;
    }

    public string Name => "help";

    public IReadOnlyList<string> Aliases => new[] { "h", "?" };

    public string Description => "Show help for all commands";

    public string Usage => "help [command name]";

    public CommandResult ExecuteCommand(CommandContext context)
    {
        var ui = context.Ui;
        var arguments = context.Arguments;

        if (arguments!.Count == 0)
        {
            var allCommands = _registry
                .GetAllCommands()
                .OrderBy(cmd => cmd.Name)
                .ToList();

            // utilize the builtin stringbuilder class
            var sb = new StringBuilder();
            sb.AppendLine("Available commands:");

            foreach (var commands in allCommands)
            {
                sb.AppendLine($" {commands.Name} - {commands.Description}");
            }

            ui!.WriteLine(sb.ToString());
            return CommandResult.SUCESS;
        }
        else
        {
            var name = arguments[0];
            if (!_registry.TryGetCommand(name, out var command))
            {
                ui!.WriteError($"Could not find a command named: '{name}'");
                return CommandResult.FAILURE;
            }

            ui!.WriteLine($"{command!.Name}");
            ui!.WriteLine($"Description: {command.Description}");
            ui!.WriteLine($"Usage: {command.Usage}");

            if (command.Aliases.Count > 0)
            {
                ui!.WriteLine($"Aliases: {string.Join(" ,", command.Aliases)}");
            }

            return CommandResult.SUCESS;
        }
    }
}