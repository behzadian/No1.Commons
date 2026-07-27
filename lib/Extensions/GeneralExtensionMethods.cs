using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class GeneralExtensionMethods
{
	public static bool HasValue<T>([NotNullWhen(true)] this T? obj) where T : notnull => obj is not null && !EqualityComparer<T>.Default.Equals(obj, default!);

	public static bool IsUsable([NotNullWhen(true)] this object? obj) => obj != null;

	public static bool IsUseless([NotNullWhen(false)] this object? obj) => obj == null;

	[return: NotNull]
	public static T Otherwise<T>(this T? value, T replacement)
	where T : notnull => value.HasValue() ? value : replacement;
}