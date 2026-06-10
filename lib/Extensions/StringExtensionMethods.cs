using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace No1.Commons.Extensions;

public static class StringExtensionMethods
{
	[return: NotNull]
	public static string OnEmpty(this string? value, string replacement) {
		ArgumentException.ThrowIfNullOrWhiteSpace(replacement);
		return value.IsUsable() ? value : replacement;
	}

	public static bool IsUsable([NotNullWhen(true)] this string? value) {
		return !string.IsNullOrWhiteSpace(value);
	}

	public static bool IsNothing([MaybeNullWhen(true)] this string? value) {
		return string.IsNullOrWhiteSpace(value);
	}
}