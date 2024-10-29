using Microsoft.Extensions.Logging;

namespace RadioControlledCarSimulator.Utilities
{
    public static class SimulationLogger
    {
        public static void LogInformation(ILogger logger, string message) => logger.LogInformation(message);
        public static void LogWarning(ILogger logger, string message) => logger.LogWarning(message);
        public static void LogError(ILogger logger, string message) => logger.LogError(message);
        public static void LogCritical(ILogger logger, string message) => logger.LogCritical(message);
        public static void LogDebug(ILogger logger, string message) => logger.LogDebug(message);
        public static void LogTrace(ILogger logger, string message) => logger.LogTrace(message);

    }
}