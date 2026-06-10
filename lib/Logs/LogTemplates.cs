using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace No1.Commons.Logs;

internal static partial class LogTemplates
{
	[LoggerMessage(Level = LogLevel.Warning, Message = "No .env file found in any of below paths:\n {searchedPaths}")]
	internal static partial void LogEnvFileNotFound(ILogger logger, string searchedPaths);
}