using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class GeneralExtensionMethods
{
	public static bool HasValue<T>([NotNullWhen(true)] this T? obj) where T : notnull => obj is not null && !EqualityComparer<T>.Default.Equals(obj, default!) && (obj is not IEnumerable e || e.GetEnumerator().MoveNext());

	public static bool IsUsable<T>([NotNullWhen(true)] this T? obj) where T : notnull => obj.HasValue();

	public static bool IsUseless<T>([NotNullWhen(false)] this T? obj) where T : notnull => !obj.HasValue();

	[return: NotNull]
	public static T Otherwise<T>(this T? value, T replacement)
	where T : notnull => value.HasValue() ? value : replacement;
}