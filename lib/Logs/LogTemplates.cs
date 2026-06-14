using Microsoft.Extensions.Logging;

namespace No1.Commons.Logs;

internal static partial class LogTemplates
{
	[LoggerMessage(Level = LogLevel.Warning, Message = "No .env file found in any of below paths:\n {searchedPaths}")]
	internal static partial void LogEnvFileNotFound(ILogger logger, string searchedPaths);
}