public interface IGameUi
{
    // wrappers around the Spectre.Console library for UI
    void WriteLine(string text);
    void WriteError(string text);
    void WriteInfo(string text);

    string ReadLines();

    void ShowPrompt(Player player);

    void ShowRoom(Room room);
}