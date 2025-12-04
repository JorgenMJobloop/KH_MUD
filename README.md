# KH_MUD v.0.0

## Depencies

### Spectre.Console
### Spectre.Console.Cli

```sh
dotnet add package Spectre.Console

dotnet add package Spectre.Console.Cli
```

## Flowchart

### Classes
    * Game
        - Core
        - World
            - Dungeon
            - Building
            - Room
        - Engine
        - UI
        - CommandProcessor
### Gameloop
    * Input
    * Parse
    * Execute
    * Output

# TODO: 02.12.2025 - 04.12.2025
    - Implement a name for the player in the Player class constructor. : Complete
    - Create a "World map" : Currently in-development
    - Create different scenarios : Currently in-development
    - Implement a set of different commands in the CommandProcessor class : Currently in-development
    - Implement dungeons & buildings
    - Create a UI-wrapper around Spectre.Console & properly render it.
    - Create a world loader
    - Create the overworld (JSON) & properly render it

