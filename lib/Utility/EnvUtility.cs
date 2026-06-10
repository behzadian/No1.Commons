using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace No1.Commons.Utility;

public static class EnvUtility
{
	public static string? GetEnvFileKey(string key) {
		return EnsureEnvFileKeyValues().TryGetValue(key, out string? value) ? value : null;
	}

	internal static readonly ConcurrentDictionary<string, string> envFileKeyValues = [];

	private static ConcurrentDictionary<string, string> EnsureEnvFileKeyValues() {
		if (!envFileKeyValues.IsEmpty) {
			return envFileKeyValues;
		}

		string start = AppContext.BaseDirectory;
		string envPath = FindFileUpwards(start, ".env");
		foreach (var raw in File.ReadLines(envPath!)) {
			var line = raw.Trim();
			if (string.IsNullOrEmpty(line) || line.StartsWith('#')) {
				continue;
			}

			var idx = line.IndexOf('=', StringComparison.InvariantCultureIgnoreCase);
			if (idx <= 0) continue;
			var lineKey = line[..idx].Trim();
			var lineVal = line[(idx + 1)..].Trim();
			// strip quotes
			if ((lineVal.StartsWith('\"') && lineVal.EndsWith('\"')) || (lineVal.StartsWith('\'') && lineVal.EndsWith('\''))) {
				lineVal = lineVal[1..^1];
			}
			envFileKeyValues[lineKey] = lineVal;
		}
		return envFileKeyValues;
	}

	private static string FindFileUpwards(string startDir, string fileName) {
		var dir = new DirectoryInfo(startDir);
		var searchedPaths = new List<string>();
		while (dir != null) {
			var candidate = Path.Combine(dir.FullName, fileName);
			if (File.Exists(candidate)) {
				return candidate;
			}
			searchedPaths.Add(dir.FullName);
			dir = dir.Parent;
		}
		throw new FileNotFoundException($"No .env file found in any of below paths:\n {string.Join("\n", searchedPaths)}");
	}
}
