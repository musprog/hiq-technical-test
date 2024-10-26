
namespace RadioControlledCarSimulator.Models;
public class Room
{
    public int Width { get; private set; }
    public int Height { get; private set; }
  
    public Room(int width, int height)
    {
        ValidateDimension(width, "Room width must be a positive integer.");
        ValidateDimension(height, "Room height must be a positive integer.");

        this.Width = width;
        this.Height = height;
    }

    private void ValidateDimension(int value, string message)
    {
        if (value <= 0)
        {
            throw new ArgumentException(message);
        }
    }

}
