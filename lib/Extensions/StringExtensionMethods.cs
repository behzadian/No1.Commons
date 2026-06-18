using System.Diagnostics.CodeAnalysis;

namespace No1.Commons.Extensions;

public static class StringExtensionMethods
{
	[Obsolete("Use " + nameof(Otherwise) + " istead")]
	[SuppressMessage("Info Code Smell", "S1133:Deprecated code should be removed", Justification = "_")]
	[return: NotNull]
	public static string OnEmpty(this string? value, string replacement) {
		return Otherwise(value, replacement);
	}

	[return: NotNull]
	public static string Otherwise(this string? value, string replacement) {
		ArgumentException.ThrowIfNullOrWhiteSpace(replacement);
		return value.IsUsable() ? value : replacement;
	}

	public static bool IsUsable([NotNullWhen(true)] this string? value) {
		return !string.IsNullOrWhiteSpace(value);
	}

	public static bool IsUseful([NotNullWhen(true)] this string? value) {
		return !string.IsNullOrWhiteSpace(value);
	}

	public static bool IsUseless([MaybeNullWhen(true)] this string? value) {
		return string.IsNullOrWhiteSpace(value);
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