using Microsoft.Extensions.Logging;
using No1.Commons.Extensions;
using No1.Commons.Logs;
using System.Collections.Concurrent;

namespace No1.Commons.Utility;

public static class EnvUtility
{
	internal static readonly ConcurrentDictionary<string, string> EnvFileKeyValues = new();

	private static readonly Lock LockObject = new();

	public static string? GetEnvFileKey(string key, ILogger? logger = null) {
		return EnsureEnvFileKeyValues(logger).TryGetValue(key, out string? value) ? value : null;
	}

	private static ConcurrentDictionary<string, string> EnsureEnvFileKeyValues(ILogger? logger = null) {
		lock (LockObject) {
			if (!EnvFileKeyValues.IsEmpty) {
				return EnvFileKeyValues;
			}

			string start = AppContext.BaseDirectory;
			var envPath = FindFileUpwards(start, logger);
			if (string.IsNullOrEmpty(envPath)) {
				return EnvFileKeyValues;
			}

			var lines = ExceptionUtility.ExecExceptionless(() => File.ReadLines(envPath), []);
			foreach (var raw in lines) {
				var line = raw.Trim();
				if (string.IsNullOrEmpty(line) || line.StartsWith('#')) {
					continue;
				}

				var idx = line.IndexOf('=', StringComparison.InvariantCultureIgnoreCase);
				if (idx <= 0) {
					continue;
				}

				var lineKey = line[..idx].Trim();
				var lineVal = line[(idx + 1)..].Trim();
				if (lineKey.IsUseless() || lineVal.IsUseless()) {
					continue;
				}

				// strip quotes
				if ((lineVal.StartsWith('\"') && lineVal.EndsWith('\"')) || (lineVal.StartsWith('\'') && lineVal.EndsWith('\''))) {
					lineVal = lineVal[1..^1];
				}

				EnvFileKeyValues[lineKey] = lineVal;
			}

			return EnvFileKeyValues;
		}
	}

	private static string? FindFileUpwards(string startDir, ILogger? logger = null) {
		var dir = new DirectoryInfo(startDir);
		var searchedPaths = new List<string>();
		while (dir != null) {
			var candidate = Path.Combine(dir.FullName, ".env");
			if (File.Exists(candidate)) {
				return candidate;
			}

			searchedPaths.Add(dir.FullName);
			dir = dir.Parent;
		}

		string joinedSearchedPaths = string.Join("\n", searchedPaths);
		if (logger.HasValue()) {
			LogTemplates.LogEnvFileNotFound(logger, joinedSearchedPaths);
			return null;
		} else {
			throw new FileNotFoundException($"No .env file found in any of below paths:\n {joinedSearchedPaths}");
		}
	}
}