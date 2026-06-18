using No1.Commons.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace No1.Commons.Extensions;

/// <summary>
/// Contains extension methods for object (all types).
/// </summary>
public static class GeneralExtensionMethods
{
	/// <summary>
	/// Returns true if object that is being called on, is not null.
	/// </summary>
	/// <param name="obj">object that is being base of call. For example. <code>obj.HasValue();</code></param>
	/// <returns>True if object was not null.</returns>
	public static bool HasValue([NotNullWhen(true)] this object? obj) => obj != null;

	/// <summary>
	/// Returns true if object that is being called on, is not null.
	/// </summary>
	/// <param name="obj">object that is being base of call. For example. <code>obj.HasValue();</code></param>
	/// <returns>True if object was not null.</returns>
	public static bool IsUsable([NotNullWhen(true)] this object? obj) => obj != null;

	/// <summary>
	/// Checks weather object is null or not.
	/// </summary>
	/// <typeparam name="T">Type of object.</typeparam>
	/// <param name="value">value to be evaluated for being null or not.</param>
	/// <param name="replacement">the value that will be return if the main value was null.</param>
	/// <returns>Value in <paramref name="value"/> if was not null, or <paramref name="replacement"/> if <paramref name="value"/> is null.</returns>
	[return: NotNull]
	public static T Otherwise<T>(this T? value, T replacement)
	where T : notnull => value.HasValue() ? value : replacement;

	/// <summary>
	/// Checks weather object is null or not.
	/// </summary>
	/// <typeparam name="T">Type of object.</typeparam>
	/// <param name="value">value to be evaluated for being null or not.</param>
	/// <param name="replacementProvider">Provides default value if the <paramref name="value"/> was null.</param>
	/// <param name="expression">Will be provided by compiler.</param>
	/// <returns>Value in <paramref name="value"/> if was not null, or result of calling <paramref name="replacementProvider"/> if <paramref name="value"/> is null.</returns>
	[return: NotNull]
	public static T Otherwise<T>(this T? value, Func<T> replacementProvider, [CallerArgumentExpression(nameof(replacementProvider))] string expression = "")
	where T : notnull {
		ArgumentNullException.ThrowIfNull(replacementProvider);
		return value.HasValue() ? value : NullExpressionException.Exec(replacementProvider, expression);
	}
}