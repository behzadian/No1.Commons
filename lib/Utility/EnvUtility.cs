using Microsoft.Extensions.Logging;
using No1.Commons.Exceptions;
using No1.Commons.Extensions;
using No1.Commons.Logs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace No1.Commons.Utility;

public static class EnvUtility
{
	public static string? GetEnvFileKey(string key, ILogger? logger = null) {
		return EnsureEnvFileKeyValues(logger).TryGetValue(key, out string? value) ? value : null;
	}

	private static readonly Lock o = new();

	internal static readonly ConcurrentDictionary<string, string> envFileKeyValues = new();

	private static ConcurrentDictionary<string, string> EnsureEnvFileKeyValues(ILogger? logger = null) {
		lock (o) {
			if (!envFileKeyValues.IsEmpty) {
				return envFileKeyValues;
			}

			string start = AppContext.BaseDirectory;
			var envPath = FindFileUpwards(start, logger);
			if (string.IsNullOrEmpty(envPath)) {
				return envFileKeyValues;
			}
			var lines = ExceptionUtility.ExecExceptionless(() => File.ReadLines(envPath), []);
			foreach (var raw in lines) {
				var line = raw.Trim();
				if (string.IsNullOrEmpty(line) || line.StartsWith('#')) {
					continue;
				}

				var idx = line.IndexOf('=', StringComparison.InvariantCultureIgnoreCase);
				if (idx <= 0) continue;
				var lineKey = line[..idx].Trim();
				var lineVal = line[(idx + 1)..].Trim();
				if (lineKey.IsNothing() || lineVal.IsNothing()) {
					continue;
				}
				// strip quotes
				if ((lineVal.StartsWith('\"') && lineVal.EndsWith('\"')) || (lineVal.StartsWith('\'') && lineVal.EndsWith('\''))) {
					lineVal = lineVal[1..^1];
				}
				envFileKeyValues[lineKey] = lineVal;
			}
			return envFileKeyValues;
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