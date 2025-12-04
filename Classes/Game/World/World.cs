public class World
{
    private readonly Dictionary<string, Room>? _rooms;

    public string? StartRoomId { get; }

    public World(string startRoomId, IEnumerable<Room> rooms)
    {
        StartRoomId = startRoomId;
        _rooms = new Dictionary<string, Room>();

        foreach (var room in rooms)
        {
            _rooms[room.Id!] = room;
        }
    }

    public Room? GetRoomById(string id)
    {
        return _rooms!.TryGetValue(id, out var room) ? room : null;
    }

}