using System.Collections.Generic;
public class CommandRegistry
{
    private readonly Dictionary<string, IGameCommand>? _commandsByKey;

    public CommandRegistry(IEnumerable<IGameCommand> commands)
    {
        _commandsByKey = new Dictionary<string, IGameCommand>();

        foreach (var command in commands)
        {
            Register(command);
        }
    }

    // public methods
    public void Register(IGameCommand command)
    {
        // internal void method (private scope)
        void AddKey(string key)
        {
            if (_commandsByKey!.ContainsKey(key))
            {
                throw new InvalidOperationException($"Commando alias: {key} is already registered!");
            }
            _commandsByKey[key] = command;
        }

        // Call the AddKey method
        AddKey(command.Name);

        foreach (var alias in command.Aliases)
        {
            AddKey(alias);
        }
    }

    public bool TryGetCommand(string nameOrAlias, out IGameCommand? command)
    {
        return _commandsByKey!.TryGetValue(nameOrAlias, out command);
    }

    public IReadOnlyCollection<IGameCommand> GetAllCommands()
    {
        return new List<IGameCommand>(new HashSet<IGameCommand>(_commandsByKey!.Values));
    }
}