﻿namespace RadioControlledCarSimulator.Extensions;
public class SimulationException : Exception
{
    public SimulationException(string message) : base(message) { }

    public SimulationException(string message, Exception innerException) : base(message, innerException) { }
}
