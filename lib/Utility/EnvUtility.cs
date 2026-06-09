using System;
using System.Collections.Generic;
using System.Text;

namespace No1.Commons.Utility;

public static class EnvUtility
{
	public static string GetEnvFileKey(string key) {
		return GetEnvFileKeyValues()[key];
	}

	private static readonly Dictionary<string, string> envFileKeyValues = [];

	private static Dictionary<string, string> GetEnvFileKeyValues() {
		if (envFileKeyValues.Count > 0) {
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
		while (dir != null) {
			var candidate = Path.Combine(dir.FullName, fileName);
			if (File.Exists(candidate)) return candidate;
			dir = dir.Parent;
		}
		throw new FileNotFoundException("No .env file found");
	}
}
