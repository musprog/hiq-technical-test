using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator.Models;

/// <summary>
/// Represents a radio-controlled car.
/// </summary>
public class Car
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Directions Direction { get; private set; }

    private readonly Room _room;

    /// <summary>
    /// Default constructor for the Car class.
    /// </summary>
    public Car()
    {
    }

    /// <summary>
    /// Constructor for the Car class with specified initial position, direction, and room.
    /// </summary>
    /// <param name="x">The initial X coordinate of the car.</param>
    /// <param name="y">The initial Y coordinate of the car.</param>
    /// <param name="direction">The initial direction of the car.</param>
    /// <param name="room">The room in which the car is located.</param>
    public Car(int x, int y, Directions direction, Room room)
    {
        X = x;
        Y = y;
        Direction = direction;
        _room = room;
    }

    /// <summary>
    /// Checks if the car's initial position is within the room range.
    /// </summary>
    /// <returns>True if the car's initial position is within the room range, false otherwise.</returns>
    public bool CarStartPosition()
    {
        return _room.IsWithinRoomRange(X, Y);
    }

    /// <summary>
    /// Moves the car forward in the current direction.
    /// </summary>
    /// <returns>True if the car successfully moved forward, false otherwise.</returns>
    public virtual bool MoveForward()
    {
        // Calculate new position based on the current direction
        (int newX, int newY) = Direction switch
        {
            Directions.N => (X, Y + 1),
            Directions.E => (X + 1, Y),
            Directions.S => (X, Y - 1),
            Directions.W => (X - 1, Y),
            _ => (X, Y) // Default case, no movement
        };

        bool result = _room.IsWithinRoomRange(newX, newY);

        if (result)
        {
            X = newX;
            Y = newY;

            SimulationIO.CarMoving(result, "forward", X, Y, Direction);
        }

        return result;
    }

    /// <summary>
    /// Moves the car backward in the opposite direction.
    /// </summary>
    /// <returns>True if the car successfully moved backward, false otherwise.</returns>
    public virtual bool MoveBackward()
    {
        // Calculate new position based on the current direction
        (int newX, int newY) = Direction switch
        {
            Directions.N => (X, Y - 1),
            Directions.E => (X - 1, Y),
            Directions.S => (X, Y + 1),
            Directions.W => (X + 1, Y),
            _ => (X, Y) // Default case, no movement
        };

        // Check if the new position is within room range
        bool success = _room.IsWithinRoomRange(newX, newY);

        // Update position only if within room range
        if (success)
        {
            X = newX;
            Y = newY;

            SimulationIO.CarMoving(success, "backward", X, Y, Direction);
        }

        return success;
    }

    /// <summary>
    /// Turns the car to the left by 90 degrees.
    /// </summary>
    /// <returns>True if the car successfully turned left, false otherwise.</returns>
    public virtual bool TurnLeft()
    {
        ChangeDirection(-1); // -1 for left turn
        return true;
    }

    /// <summary>
    /// Turns the car to the right by 90 degrees.
    /// </summary>
    /// <returns>True if the car successfully turned right, false otherwise.</returns>
    public virtual bool TurnRight()
    {
        ChangeDirection(1); // 1 for right turn
        return true;
    }

    private void ChangeDirection(int directionChange)
    {
        Direction = directionChange switch
        {
            -1 => Direction switch
            {
                Directions.N => Directions.W,
                Directions.E => Directions.N,
                Directions.S => Directions.E,
                Directions.W => Directions.S,
                _ => Direction
            },
            1 => Direction switch
            {
                Directions.N => Directions.E,
                Directions.E => Directions.S,
                Directions.S => Directions.W,
                Directions.W => Directions.N,
                _ => Direction
            },
            _ => Direction
        };

        string side = directionChange == 1 ? "right" : "left";

        SimulationIO.CarTurning(side, X, Y, Direction);
    }

    /// <summary>
    /// Draws the car and the room on the console.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task Draw()
    {
        Task task = Task.Delay(1);
        for (int y = _room.Height - 1; y >= 0; y--)
        {
            for (int x = 0; x < _room.Width; x++)
            {
                if (x == X && y == Y)
                {
                    Console.Write(Direction switch
                    {
                        Directions.N => "↑ ",
                        Directions.E => "→ ",
                        Directions.S => "↓ ",
                        Directions.W => "← ",
                        _ => "C "
                    });
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        return Task.CompletedTask;
    }

    /// <summary>
    /// Returns a string representation of the car's position and direction.
    /// </summary>
    /// <returns>A string representation of the car's position and direction.</returns>
    public override string ToString()
    {
        return $"Position: ({X}, {Y}), Heading: {Direction}";
    }
}
