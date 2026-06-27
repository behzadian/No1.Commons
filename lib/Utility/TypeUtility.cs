using System.Reflection;

namespace No1.Commons.Utility;

public static class TypeUtility
{
	public static Type? ResolveType(string name) {
		if (string.IsNullOrWhiteSpace(name)) {
			return null;
		}

		// 1. Fully qualified (contains assembly info)
		// Example: "MyApp.Models.User, MyApp"
		if (name.Contains(',', StringComparison.InvariantCultureIgnoreCase)) {
			return Type.GetType(name);
		}

		// 2. Has namespace (e.g. "MyApp.Models.User")
		if (name.Contains('.', StringComparison.InvariantCultureIgnoreCase)) {
			var type = Type.GetType(name);

			if (type != null) {
				return type;
			}
		}

		// 3. Simple name only -> search all loaded assemblies
		if (Array.Find(Assembly.GetExecutingAssembly().GetTypes(), t => t?.Name == name) is { } foundType) {
			return foundType;
		}

		var match = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(a => {
				try {
					return a.GetTypes();
				} catch (ReflectionTypeLoadException ex) {
					return ex.Types.Where(t => t != null)!;
				}
			})
			.FirstOrDefault(t => t?.Name == name);

		// Return only if unambiguous
		return match;
	}
}