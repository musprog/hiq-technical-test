using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Utilities;

public static class Mapper
{
    public static string ToDirections(Directions input) => input switch
    {
        Directions.N => "North",
        Directions.E => "East",
        Directions.S => "South",
        Directions.W => "West",
        _ => "Unknown"
    };

}