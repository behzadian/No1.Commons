using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

/// <summary>
/// Contains IEnumerable&lt;T&gt; extension methods.
/// </summary>
public static class CollectionExtensionMethods
{
	/// <summary>
	/// Checks weather IEnumerable is null or empty.
	/// </summary>
	/// <typeparam name="T">IEnumerable generic type.</typeparam>
	/// <param name="value">IEnumerable instance.</param>
	/// <returns>True if IEnumerable is not null and has at least one value, False on otherwise.</returns>
	public static bool IsUsable<T>([NotNullWhen(true)] this IEnumerable<T>? value) => value?.Any() == true;

	/// <summary>
	/// Checks weather IEnumerable is null or empty.
	/// </summary>
	/// <typeparam name="T">IEnumerable generic type.</typeparam>
	/// <param name="value">IEnumerable instance.</param>
	/// <returns>True if IEnumerable is null or is empty, False on otherwise.</returns>
	public static bool IsUseless<T>([MaybeNull] this IEnumerable<T>? value) => value?.Any() != true;
}