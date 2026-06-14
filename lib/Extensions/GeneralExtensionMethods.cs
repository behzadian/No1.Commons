using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class GeneralExtensionMethods
{
	public static bool HasValue([NotNullWhen(true)] this object? obj) => obj != null;

	public static bool IsUsable<T>([NotNullWhen(true)] this IEnumerable<T>? value) => value?.Any() == true;
}