
namespace RadioControlledCarSimulator.Models;
public class Room
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public Room(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public bool IsWithinRoomRange(int x, int y) => x > 0 && x < Width && y > 0 && y < Height;
}
