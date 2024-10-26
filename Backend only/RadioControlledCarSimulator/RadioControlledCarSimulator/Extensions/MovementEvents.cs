
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Extensions
{
    public class MovementEvents : EventArgs
    {
        public int X { get; init; }
        public int Y { get; init; }
        public Movements Movements { get; init; }
        public Directions Directions { get; init; }
        public bool Success { get; init; }
        public MovementEvents(int x, int y, Movements movements, Directions directions, bool success) {
            X = x;
            Y = y;
            Movements = movements;
            Directions = directions;
            Success = success;
        }
    }
}
