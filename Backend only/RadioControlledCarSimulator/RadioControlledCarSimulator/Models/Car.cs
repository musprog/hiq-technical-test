
using RadioControlledCarSimulator.Extensions;

namespace RadioControlledCarSimulator.Models;
public class Car
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Directions Direction { get; private set; }

    private readonly Room room;

    public event EventHandler<MovementEvents>? CarEvents;


    public Car(int x, int y, Directions direction, Room room)
    {
        X = x;
        Y = y;
        Direction = direction;
        this.room = room;
    }

    private bool IsWithinRoomRange(int x, int y) => x > 0 && x < room.Width && y > 0 && y < room.Height;

    public bool MoveForward()
    {
        // Calculate new position based on the current direction
        (int newX, int newY) = Direction switch
        {
            Directions.North => (X, Y - 1),
            Directions.East => (X + 1, Y),
            Directions.South => (X, Y + 1),
            Directions.West => (X - 1, Y),
            _ => (X, Y) // Default case, no movement
        };

        // Check if the new position is within room range
        bool success = IsWithinRoomRange(newX, newY);

        // Update position only if within room rang
        if (success)
        {
            (X, Y) = (newX, newY);
        }

        // Raise the Car movement event
        CarEvents?.Invoke(this, new MovementEvents(X, Y, Movements.Forward, Direction, success));

        return success;
    }

    public bool MoveBackward()
    {
        // Calculate new position based on the current direction
        (int newX, int newY) = Direction switch
        {
            Directions.North => (X, Y + 1),
            Directions.East => (X - 1, Y),
            Directions.South => (X, Y - 1),
            Directions.West => (X + 1, Y),
            _ => (X, Y) // Default case, no movement
        };

        // Check if the new position is within room rang
        bool success = IsWithinRoomRange(newX, newY);

        // Update position only if within room rang
        if (success)
        {
            (X, Y) = (newX, newY);
        }

        // Raise the Car movement event
        CarEvents?.Invoke(this, new MovementEvents(X, Y, Movements.Backward, Direction, success));

        return success;
    }

    public void TurnLeft()
    {
        ChangeDirection(-1); // -1 for left turn
    }

    public void TurnRight()
    {
        ChangeDirection(1); // 1 for right turn
    }

    private void ChangeDirection(int directionChange)
    {
        Direction = directionChange switch
        {
            -1 => Direction switch
            {
                Directions.North => Directions.West,
                Directions.East => Directions.North,
                Directions.South => Directions.East,
                Directions.West => Directions.South,
                _ => Direction
            },
            1 => Direction switch
            {
                Directions.North => Directions.East,
                Directions.East => Directions.South,
                Directions.South => Directions.West,
                Directions.West => Directions.North,
                _ => Direction
            },
            _ => Direction
        };

        // Raise the Car movement event
        CarEvents?.Invoke(this, new MovementEvents(X, Y, directionChange == -1 ? Movements.Left : Movements.Right, Direction, true));
    }

}
