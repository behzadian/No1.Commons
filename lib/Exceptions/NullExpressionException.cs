using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace No1.Commons.Exceptions;

[SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Not Needed")]
public class NullExpressionException(string? message = null) : Exception(message)
{
	[return: NotNull]
	public static T Exec<T>(Func<T> func, [CallerArgumentExpression(nameof(func))] string expression = "") {
		ArgumentNullException.ThrowIfNull(func);
		return func() ?? throw new NullExpressionException($"`{expression}` returned NULL.");
	}
}