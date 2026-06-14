using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class GeneralExtensionMethods
{
	public static bool HasValue([NotNullWhen(true)] this object? obj) => obj != null;

	public static bool IsUsable([NotNullWhen(true)] this object? obj) => obj != null;

	[return: NotNull]
	public static T Otherwise<T>(this T? value, T replacement)
	where T : notnull => value.HasValue() ? value : replacement;
}