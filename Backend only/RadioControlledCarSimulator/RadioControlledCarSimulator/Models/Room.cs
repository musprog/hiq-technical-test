namespace RadioControlledCarSimulator.Models;

/// <summary>
/// Represents a room in the Radio Controlled Car Simulator.
/// </summary>
public class Room
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Room class with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the room.</param>
    /// <param name="height">The height of the room.</param>
    public Room(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    /// <summary>
    /// Checks if the specified coordinates are within the range of the room.
    /// </summary>
    /// <param name="x">The x-coordinate.</param>
    /// <param name="y">The y-coordinate.</param>
    /// <returns>True if the coordinates are within the range of the room, otherwise false.</returns>
    public bool IsWithinRoomRange(int x, int y) => x > 0 && x < Width && y > 0 && y < Height;
}
