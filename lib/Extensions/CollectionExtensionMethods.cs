using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class CollectionExtensionMethods
{
	public static bool IsUsable<T>([NotNullWhen(true)] this IEnumerable<T>? value) => value?.Any() == true;

	public static bool IsUseless<T>([MaybeNull] this IEnumerable<T>? value) => value?.Any() != true;
}