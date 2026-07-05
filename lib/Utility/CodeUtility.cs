using System.Runtime.CompilerServices;

namespace No1.Commons.Utility;

public static class CodeUtility
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1163:Unused parameter", Justification = "Needed")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Needed")]
	public static string ExpressionOf(Func<object> action, [CallerArgumentExpression(nameof(action))] string expression = "") => expression;
}