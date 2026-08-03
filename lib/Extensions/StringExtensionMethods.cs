using No1.Commons.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class StringExtensionMethods
{
	[return: NotNull]
	public static string Otherwise(this string? value, string replacement) {
		ArgumentException.ThrowIfNullOrWhiteSpace(replacement);
		return value.HasValue() ? value : replacement;
	}

	[return: NotNull]
	public static string Otherwise(this string? value, Func<string> replacementProvider) {
		ArgumentNullException.ThrowIfNull(replacementProvider);
		return value.HasValue() ? value : NullExpressionException.Exec(() => replacementProvider());
	}

	public static bool IsUsable([NotNullWhen(true)] this string? value) {
		return value.HasValue();
	}

	public static bool IsUseful([NotNullWhen(true)] this string? value) {
		return value.HasValue();
	}

	public static bool IsUseless([NotNullWhen(false)] this string? value) {
		return !value.HasValue();
	}

	[return: NotNull]
	public static string StripEnd(this string value, string removing, StringComparison comparison = StringComparison.InvariantCulture) {
		ArgumentException.ThrowIfNullOrWhiteSpace(value);
		ArgumentException.ThrowIfNullOrWhiteSpace(removing);

		if (!value.EndsWith(removing, comparison)) {
			return value;
		}

		return value[0..^removing.Length];
	}
}