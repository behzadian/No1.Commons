using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace No1.Commons.Exceptions;

/// <summary>
/// Use this exception and its static method <see cref="Exec{T}"/> to get detailed null exceptions.
/// </summary>
/// <param name="message">Indicates that which expression returned NULL.</param>
[SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Not Needed")]
public class NullExpressionException(string? message = null) : Exception(message)
{
	/// <summary>
	/// Executes func object that is passed via <paramref name="func"/> and return the result.
	/// If the result was null, then throws a NullExpressionException with appropriate message.
	/// </summary>
	/// <param name="func">Func to be executed.</param>
	/// <param name="expression">Func expression that will be provided by C# compiler for providing meaningful exception message.</param>
	/// <typeparam name="T">Returned type of <paramref name="func"/>.</typeparam>
	/// <returns>Not null result of expression.</returns>
	/// <exception cref="ArgumentNullException">If the parameter <paramref name="func"/> was null.</exception>
	/// <exception cref="NullExpressionException">When the output of <paramref name="func"/> execution is null.</exception>
	/// <example>
	/// Imagine there is a C# expression like `a.b().c["d"] ? g` that its output is string.
	/// But you want to be sure of the output. There are several ways to execute it:
	/// 1. Use `?? throw ` expression like below:
	/// <code>
	/// var result = a.b().c["d"] ? g ?? throw new Exception("Result of expression `a.b().c["d"] ? g` is null.");
	/// </code>
	/// As you can see this code is long and not only exception message must be provided, but also on every usage, a different exception message
	/// can be written by developers.
	/// 2. Use `!` at the end of expression.
	/// This method is only good when you 100% sure that the result is not null:
	/// <code>
	/// var result = (a.b().c["d"] ? g)!
	/// </code>
	/// Then what if the output was null? A meaningless exception!
	/// 3. Use this method.
	/// So you can use below expression:
	/// <code>
	/// var result = NullExpressionException.Exec(()=>a.b().c["d"] ? g);
	/// </code>
	/// Here result will be valuable (not null) or an exception with standard message had been thrown.
	/// As this method is generic and its output type is fixed, you can write above code like:
	/// <code>
	/// MyCustomType result = NullExpressionException.Exec(()=>a.b().c["d"] ? g);
	/// </code>
	/// Also you can provide the exact type (As c# compiler checks for output and also detect it, it is not necessary):
	/// <code>
	/// MyCustomType result = NullExpressionException.Exec&lt;MyCustomType&gt;(()=>a.b().c["d"] ? g);
	/// </code>
	/// </example>
	[return: NotNull]
	public static T Exec<T>(Func<T> func, [CallerArgumentExpression(nameof(func))] string expression = "") {
		ArgumentNullException.ThrowIfNull(func);
		return func() ?? throw new NullExpressionException($"`{expression}` returned NULL.");
	}
}